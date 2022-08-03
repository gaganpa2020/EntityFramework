using System;

namespace DotnetCoreORMDemo.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public string customerID { get; set; }
        public int? employeeID { get; set; }
        public DateTime? orderDate { get; set; }
        public DateTime? requiredDate { get; set; }
        public DateTime? shippedDate { get; set; }
        public int? shipVia { get; set; }
        public decimal? freight { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipRegion { get; set; }
        public string shipPostalCode { get; set; }
        public string shipCountry { get; set; }

        public override string ToString()
        {
            string cr = Environment.NewLine;

            return
                "OrderID        : " + orderID + cr +
                "CustomerID     : " + customerID + cr +
                "EmployeeID     : " + employeeID + cr +
                "OrderDate      : " + orderDate + cr +
                "RequiredDate   : " + requiredDate + cr +
                "ShippedDate    : " +shippedDate + cr +
                "ShipVia        : " +shipVia + cr +
                "Freight        : " + freight + cr +
                "ShipName       : " + shipName + cr +
                "ShipAddress    : " +shipAddress + cr +
                "ShipCity       : " + shipCity + cr +
                "ShipRegion     : " +shipRegion + cr +
                "ShipPostalCode : " + shipPostalCode + cr +
                "ShipCountry    : " + shipCountry;
        }
    }
}
