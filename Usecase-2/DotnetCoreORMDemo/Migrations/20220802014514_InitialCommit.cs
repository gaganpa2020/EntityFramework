using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetCoreORMDemo.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeID = table.Column<int>(type: "int", nullable: true),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    shippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    shipVia = table.Column<int>(type: "int", nullable: true),
                    freight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    shipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderID);
                });

            migrationBuilder.CreateTable(
                name: "WritableRows",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritableRows", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WritableRows");
        }
    }
}
