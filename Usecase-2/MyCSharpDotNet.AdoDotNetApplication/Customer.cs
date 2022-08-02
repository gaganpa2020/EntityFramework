using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpDotNet.AdoDotNetApplication
{
    static class Customer
    {
        public static List<string> GetCustomerIDs()
        {
            List<string> customerIDs = new List<string>();

            string queryString = 
                "SELECT CustomerID " +
                    "FROM Customers";

            using (SqlConnection sqlConnection =
                new SqlConnection(Tools.ConnectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                EnhancedSqlDataReader enhancedSqlDataReader =
                    new EnhancedSqlDataReader(sqlCommand.ExecuteReader());

                while (enhancedSqlDataReader.Read())
                {
                    customerIDs.Add(
                        enhancedSqlDataReader.GetString("CustomerID"));
                }

                enhancedSqlDataReader.Close();
            }

            return customerIDs;
        }
    }
}
