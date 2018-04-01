using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.Models;
using StudentManagementApp.Getways;

namespace DiagnosticCenterBillManagementSystemApp.Getways
{
    public class TestTypeGetway
    {
        private Getway _getway=new Getway();

        public int Save(TestType testType)
        {
            string query = "INSERT INTO TestTypes(Name) VALUES('" + testType.Name + "')";
            return _getway.ExecuteNonQuery(query, _getway.ConnectionString());
        }

        public int Update(TestType testType, int id)
        {
            string query = "UPDATE TestTypes SET Name='" + testType.Name + "' WHERE Id='" + id + "'";
            return _getway.ExecuteNonQuery(query, _getway.ConnectionString());
        }

        public int Delete(int id)
        {
            string query = "UPDATE TestTypes SET IsDeleted='" + true + "' WHERE Id='" + id + "'";
            return _getway.ExecuteNonQuery(query, _getway.ConnectionString());
        }

        public List<TestType> GetAll()
        {
            var typeList = new List<TestType>();
            var serial = 1;
            string query = "SELECT * FROM TestTypes WHERE IsDeleted IS NULL Order By Name";
            var reader = _getway.Reader(query, _getway.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var testType = new TestType();
                    testType.Id = Convert.ToInt32(reader["Id"]);
                    testType.Serial = serial;
                    testType.Name = reader["Name"].ToString();

                    typeList.Add(testType);

                    serial++;
                }
            }
            reader.Close();

            return typeList;
        }

        public TestType GetByTypeName(string name)
        {
            TestType testType = null;

            string query = "SELECT * FROM TestTypes WHERE Name='" + name + "' AND IsDeleted IS NULL";
            var reader = _getway.Reader(query, _getway.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                testType=new TestType();
                testType.Id = Convert.ToInt32(reader["Id"]);
                testType.Serial = 1;
                testType.Name = reader["Name"].ToString();
            }

            reader.Close();
            return testType;
        }
    }
}