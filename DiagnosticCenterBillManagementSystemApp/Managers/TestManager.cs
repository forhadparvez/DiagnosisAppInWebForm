using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.Getways;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.Managers
{
    public class TestManager
    {
        private TestGetway _testGetway=new TestGetway();

        public int Save(Test aTest)
        {
            return _testGetway.Save(aTest);
        }

        public int Update(int id, Test aTest)
        {
            return _testGetway.Update(id, aTest);
        }

        public int Delete(int id)
        {
            return _testGetway.Delete(id);
        }

        public List<Test> GetAll()
        {
            return _testGetway.GetAll();
        }

        public Test GetTestByName(string name)
        {
            return _testGetway.GetTestByName(name);
        }

        public Test GetTestByNameAndType(string name, int testTypeId)
        {
            return _testGetway.GetTestByNameAndType(name, testTypeId);
        }

        // Unique
        public bool IsNameExist(string name, int testTypeId)
        {
            bool isNameExist = false;
            var aTest = GetTestByNameAndType(name, testTypeId);
            if (aTest!=null)
            {
                isNameExist = true;
            }
            return isNameExist;
        }

        public Test GetById(int testId)
        {
            return _testGetway.GetById(testId);
        }
    }
}