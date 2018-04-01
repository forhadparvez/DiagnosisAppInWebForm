using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.Managers
{
    public class TestRequestManager
    {
        public List<Test> GetViewState(Test aTest, object viewState)
        {
            int serial = 1;
            var testList = (List<Test>) viewState;
            testList.Add(aTest);

            foreach (var test in testList)
            {
                test.Serial = serial;
                serial++;
            }

            return testList;
        }
    }
}