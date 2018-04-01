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
    public partial class TestRequestEntryForm : System.Web.UI.Page
    {
        private TestManager _testManager=new TestManager();
        private TestRequestManager _testRequestManager=new TestRequestManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                testDropDownList.DataSource = _testManager.GetAll();
                testDropDownList.DataTextField = "Name";
                testDropDownList.DataValueField = "Id";
                testDropDownList.DataBind();

                testDropDownList.Items.Insert(0,"");
                testDropDownList.SelectedIndex = -1;

                feeTextBox.Text = "0.00";
                totalAmountTextBox.Text = "0.00";

                LoadViewState();
            }
        }


        private void LoadViewState()
        {
            ViewState["AssignedTest"] = null;
            var testList = new List<Test>();
            ViewState["AssignedTest"] = testList;
        }

        protected void testDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testDropDownList.SelectedItem.Text!="")
            {
                var testId = Convert.ToInt32(testDropDownList.SelectedValue);
                var aTest = _testManager.GetById(testId);
                if (aTest!=null)
                {
                    feeTextBox.Text = aTest.Fee.ToString();
                }
            }
            else
            {
                feeTextBox.Text = "0.00";
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.CssClass = "alert alert-default";

            if (patientNameTextBox.Text=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Insert Patient Name";
                patientNameTextBox.Focus();
            }
            else if(dateOfBirthTextBox.Text=="")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Insert Patient Date of Birth";
                dateOfBirthTextBox.Focus();
            }
            else if (mobileNoTextBox.Text == "")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Insert Patient Mobile No";
                dateOfBirthTextBox.Focus();
            }
            else if (testDropDownList.SelectedItem.Text == "")
            {
                messageLabel.CssClass = "alert alert-warning";
                messageLabel.Text = "Please Selet Test";
                testDropDownList.Focus();
            }
            else
            {
                var aTest = new Test();
                aTest.Id = Convert.ToInt32(testDropDownList.SelectedValue);
                aTest.Name = testDropDownList.SelectedItem.Text;
                aTest.Fee = Convert.ToDecimal(feeTextBox.Text);

                // Total Fee Cal
                var fee = Convert.ToDecimal(feeTextBox.Text);
                var total = Convert.ToDecimal(totalAmountTextBox.Text);
                total = total + fee;
                totalAmountTextBox.Text = total.ToString();

                var testList = _testRequestManager.GetViewState(aTest, ViewState["AssignedTest"]);

                testRequestGridView.DataSource = testList;
                testRequestGridView.DataBind();
            }
            

        }


    }
}