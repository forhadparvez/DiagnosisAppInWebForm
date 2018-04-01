﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.Getways;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.Managers
{
    public class TestTypeManager
    {
        private TestTypeGetway _testTypeGetway = new TestTypeGetway();


        public string Save(TestType testType)
        {
            int success = _testTypeGetway.Save(testType);
            if (success>0)
            {
                return "Save Success";
            }
            else
            {
                return "Save Fail";
            }
        }

        public string Update(TestType testType, int id)
        {
            int success = _testTypeGetway.Update(testType, id);
            if (success > 0)
            {
                return "Update Success";
            }
            else
            {
                return "Update Fail";
            }
        }

        public string Delete(int id)
        {
            int success = _testTypeGetway.Delete(id);
            if (success > 0)
            {
                return "Success Delete";
            }
            else
            {
                return "Delete Fail";
            }
        }

        public List<TestType> GetAll()
        {
            return _testTypeGetway.GetAll();
        }

        public TestType GetByTypeName(string name)
        {
            return _testTypeGetway.GetByTypeName(name);
        }

        // For Unique Check
        public bool IsTypeNameExist(string name)
        {
            var isTypeNameExist = false;
            var testType = GetByTypeName(name);
            if (testType!=null)
            {
                isTypeNameExist = true;
            }
            return isTypeNameExist;
        }
    }
}