using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Getways
{
    public class Getway
    {

        public string ConnectionString()
        {
            string connectionString =
                @"Server=DESKTOP-U3DSCCD;Database=DiagnosticCenterDb;User Id=sa; Password=123; Trusted_Connection=false;";
            return connectionString;
        }

        public int ExecuteNonQuery(string query, string connectionString)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();

                var command = new SqlCommand(query, connection);
                int success = command.ExecuteNonQuery();
                connection.Close();
                return success;
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

        public SqlDataReader Reader(string query, string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}
