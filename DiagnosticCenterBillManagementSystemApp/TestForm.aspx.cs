using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemApp.Managers;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestForm : System.Web.UI.Page
    {
        private  TestTypeManager _testTypeManager=new TestTypeManager();
        private TestManager _testManager=new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllDropDown();
                LoadAllGridView();
            }
        }

        public void LoadAllGridView()
        {
            testGridView.DataSource = _testManager.GetAll();
            testGridView.DataBind();
        }

        public void LoadAllDropDown()
        {
            testTypeDropDownList.DataSource = _testTypeManager.GetAll();
            testTypeDropDownList.DataTextField = "Name";
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataBind();

            testTypeDropDownList.Items.Insert(0,"");
            testTypeDropDownList.SelectedIndex = -1;
        }

        public void RefressForm()
        {
            idHiddenField.Value = "";
            testNameTextBox.Text = "";
            feeTextBox.Text = "";
            testTypeDropDownList.SelectedIndex = -1;

            LoadAllGridView();
        }


        public Test SetFormValueInModel()
        {
            var aTest = new Test();
            aTest.Name = testNameTextBox.Text;
            aTest.Fee = Convert.ToDecimal(feeTextBox.Text);
            aTest.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);

            return aTest;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";

            if (testNameTextBox.Text=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Insert Test Name";
                testNameTextBox.Focus();
            }
            else if (feeTextBox.Text=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Insert Test Fee";
                feeTextBox.Focus();
            }
            else if (testTypeDropDownList.SelectedValue=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Select Test Type";
                testTypeDropDownList.Focus();
            }
            else
            {
                var test = SetFormValueInModel();
                var isNameExist = _testManager.IsNameExist(test.Name, test.TestTypeId);
                if (isNameExist)
                {
                    messageLabel.CssClass = "alert alert-warning";
                    messageLabel.Text = "This Test Name Already In Database";
                }
                else
                {
                    var success = _testManager.Save(test);
                    if (success>0)
                    {
                        messageLabel.CssClass = "alert alert-success";
                        messageLabel.Text = "Save Success";

                        RefressForm();
                    }
                    else
                    {
                        messageLabel.CssClass = "alert alert-danger";
                        messageLabel.Text = "Save Fail";
                    }
                }
            }
           
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.CssClass = "alert alert-default";
            if (testNameTextBox.Text=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Insert Test Name";
                testNameTextBox.Focus();
            }
            else
            {
                var testName = testNameTextBox.Text;
                var aTest = _testManager.GetTestByName(testName);
                if (aTest!=null)
                {
                    idHiddenField.Value = aTest.Id.ToString();
                    testNameTextBox.Text = aTest.Name;
                    feeTextBox.Text = aTest.Fee.ToString("N2");
                    testTypeDropDownList.SelectedValue = aTest.TestTypeId.ToString();


                    var testList = new List<Test>();
                    testList.Add(aTest);

                    testGridView.DataSource = testList;
                    testGridView.DataBind();

                }
                else
                {
                    messageLabel.CssClass = "alert alert-info";
                    messageLabel.Text = "There is no Test in This Name";
                }
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.CssClass = "alert alert-default";

            if (idHiddenField.Value=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "First Find a Test Then Update";
            }
            else
            {
                var test = SetFormValueInModel();
                var isNameExist = _testManager.IsNameExist(test.Name, test.TestTypeId);
                if (isNameExist)
                {
                    messageLabel.CssClass = "alert alert-warning";
                    messageLabel.Text = "This Test Name Already In Database";
                }
                else
                {
                    var id = Convert.ToInt32(idHiddenField.Value);
                    var success = _testManager.Update(id,test);
                    if (success > 0)
                    {
                        messageLabel.CssClass = "alert alert-success";
                        messageLabel.Text = "Update Success";

                        RefressForm();
                    }
                    else
                    {
                        messageLabel.CssClass = "alert alert-danger";
                        messageLabel.Text = "Update Fail";
                    }
                }
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.CssClass = "alert alert-default";

            if (idHiddenField.Value == "")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "First Find a Test Then Update";
            }
            else
            {
                var id = Convert.ToInt32(idHiddenField.Value);
                    var success = _testManager.Delete(id);
                    if (success > 0)
                    {
                        messageLabel.CssClass = "alert alert-success";
                        messageLabel.Text = "Delete Success";

                        RefressForm();
                    }
                    else
                    {
                        messageLabel.CssClass = "alert alert-danger";
                        messageLabel.Text = "Delete Fail";
                    }
                }
            }
        }
    }
