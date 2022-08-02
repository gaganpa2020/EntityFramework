using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyCSharpDotNet.AdoDotNetApplication
{
    class Order
    {
        int orderID;
        string customerID;
        int? employeeID;
        DateTime? orderDate;
        DateTime? requiredDate;
        DateTime? shippedDate;
        int? shipVia;
        decimal? freight;
        string shipName;
        string shipAddress;
        string shipCity;
        string shipRegion;
        string shipPostalCode;
        string shipCountry;

        private Order(
            int orderID,
            string customerID,
            int? employeeID,
            DateTime? orderDate,
            DateTime? requiredDate,
            DateTime? shippedDate,
            int? shipVia,
            decimal? freight,
            string shipName,
            string shipAddress,
            string shipCity,
            string shipRegion,
            string shipPostalCode,
            string shipCountry)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.employeeID = employeeID;
            this.orderDate = orderDate;
            this.requiredDate = requiredDate;
            this.shippedDate = shippedDate;
            this.shipVia = shipVia;
            this.freight = freight;
            this.shipName = shipName;
            this.shipAddress = shipAddress;
            this.shipCity = shipCity;
            this.shipRegion = shipRegion;
            this.shipPostalCode = shipPostalCode;
            this.shipCountry = shipCountry;
        }

        public override string ToString()
        {
            string cr = Environment.NewLine;

            return
                "OrderID        : " + orderID + cr +
                "CustomerID     : " + Tools.WriteNullForNull(customerID) + cr +
                "EmployeeID     : " + Tools.WriteNullForNull(employeeID) + cr +
                "OrderDate      : " + Tools.WriteNullForNull(orderDate) + cr +
                "RequiredDate   : " + Tools.WriteNullForNull(requiredDate) + cr +
                "ShippedDate    : " + Tools.WriteNullForNull(shippedDate) + cr +
                "ShipVia        : " + Tools.WriteNullForNull(shipVia) + cr +
                "Freight        : " + Tools.WriteNullForNull(freight) + cr +
                "ShipName       : " + Tools.WriteNullForNull(shipName) + cr +
                "ShipAddress    : " + Tools.WriteNullForNull(shipAddress) + cr +
                "ShipCity       : " + Tools.WriteNullForNull(shipCity) + cr +
                "ShipRegion     : " + Tools.WriteNullForNull(shipRegion) + cr +
                "ShipPostalCode : " + Tools.WriteNullForNull(shipPostalCode) + cr +
                "ShipCountry    : " + Tools.WriteNullForNull(shipCountry);
        }

        public static List<Order> GetOrdersByCustomerID(string customerID)
        {
            List<Order> orders = new List<Order>();

            string queryString =
                "SELECT * " +
                    "FROM Orders " +
                    "WHERE CustomerID = @CustomerID";

            using (SqlConnection sqlConnection =
                new SqlConnection(Tools.ConnectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                SqlParameter customerIDSqlParameter =
                    sqlCommand.CreateParameter();
                customerIDSqlParameter.ParameterName = "CustomerID";
                customerIDSqlParameter.Value = customerID;
                sqlCommand.Parameters.Add(customerIDSqlParameter);

                sqlConnection.Open();

                EnhancedSqlDataReader enhancedSqlDataReader =
                    new EnhancedSqlDataReader(sqlCommand.ExecuteReader());

                while (enhancedSqlDataReader.Read())
                {
                    Order order = new Order(
                        enhancedSqlDataReader.GetInt32("OrderID"),
                        enhancedSqlDataReader.GetString("CustomerID"),
                        enhancedSqlDataReader.GetNullableInt32("EmployeeID"),
                        enhancedSqlDataReader.GetNullableDateTime("OrderDate"),
                        enhancedSqlDataReader.GetNullableDateTime("RequiredDate"),
                        enhancedSqlDataReader.GetNullableDateTime("ShippedDate"),
                        enhancedSqlDataReader.GetNullableInt32("ShipVia"),
                        enhancedSqlDataReader.GetNullableDecimal("Freight"),
                        enhancedSqlDataReader.GetString("ShipName"),
                        enhancedSqlDataReader.GetString("ShipAddress"),
                        enhancedSqlDataReader.GetString("ShipCity"),
                        enhancedSqlDataReader.GetString("ShipRegion"),
                        enhancedSqlDataReader.GetString("ShipPostalCode"),
                        enhancedSqlDataReader.GetString("ShipCountry")
                        );

                    orders.Add(order);
                }

                enhancedSqlDataReader.Close();
            }

            return orders;
        }
    }
}
