using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemApp.Getways;
using DiagnosticCenterBillManagementSystemApp.Managers;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestTypeForm : System.Web.UI.Page
    {
        private TestTypeManager _testTypeManager=new TestTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();   
        }

        public void LoadGridView()
        {
            testTypeGridView.DataSource = _testTypeManager.GetAll();
            testTypeGridView.DataBind();
            
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (typeNameTextBox.Text!="")
            {
                var testType = new TestType();
                testType.Name = typeNameTextBox.Text;

                var isTypenameExist = _testTypeManager.IsTypeNameExist(testType.Name);
                if (isTypenameExist)
                {
                    messageLabel.Text = "This Test Type Name Already in Database";
                }
                else
                {
                    messageLabel.Text = _testTypeManager.Save(testType);
                    RefressForm();
                }
                
                
            }
            else
            {
                messageLabel.Text = "Please Insert Test Name";
                messageLabel.CssClass = "alert alert-warning";
            }
        }

        public void RefressForm()
        {
            typeNameTextBox.Text = "";
            LoadGridView();
        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            if (typeNameTextBox.Text!="")
            {
                var testType = _testTypeManager.GetByTypeName(typeNameTextBox.Text);
                if (testType!=null)
                {
                    messageLabel.Text = "Successfuly Find Test Type";
                    idHiddenField.Value = testType.Id.ToString();
                    typeNameTextBox.Text = testType.Name;

                    var testTypeList = new List<TestType>();
                    testTypeList.Add(testType);

                    testTypeGridView.DataSource = testTypeList;
                    testTypeGridView.DataBind();
                }
                else
                {
                    messageLabel.Text = "This Test Type Not Find in Database";
                }
            }
            else
            {
                messageLabel.Text = "Please insert Test Type Name then Find";
                typeNameTextBox.Focus();
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (idHiddenField.Value=="")
            {
                messageLabel.Text = "First Find a Test Type Then Update it";
                messageLabel.CssClass = "alert alert-warning";
            }
            if (typeNameTextBox.Text != "")
            {
                int id = Convert.ToInt32(idHiddenField.Value);

                var testType = new TestType();
                testType.Name = typeNameTextBox.Text;

                var isTypenameExist = _testTypeManager.IsTypeNameExist(testType.Name);
                if (isTypenameExist)
                {
                    messageLabel.Text = "This Test Type Name Already in Database";
                }
                else
                {
                    messageLabel.Text = _testTypeManager.Update(testType,id);
                    RefressForm();
                }


            }
            else
            {
                messageLabel.Text = "Please Insert Test Name";
                messageLabel.CssClass = "alert alert-warning";
            }

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            if (idHiddenField.Value == "")
            {
                messageLabel.Text = "First Find a Test Type Then Update it";
                messageLabel.CssClass = "alert alert-warning";
            }
            else
            {
                int id = Convert.ToInt32(idHiddenField.Value);
                messageLabel.Text = _testTypeManager.Delete(id);
                RefressForm();
            }
            

        }
    }
}