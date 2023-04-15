using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoqiaGateApi.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FamilySize", "FatherName", "FirstName", "GrandfatherName", "LastName", "MobileNumber", "NationalId", "POBox", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", 3, "Doe", "John", "Johnson", "Smith", "555-5678", "1234567890", "1234", "555-1234", "10001" },
                    { 2, "jane.doe@example.com", 4, "Doe", "Jane", "Smith", "Johnson", "555-8765", "0987654321", "5678", "555-4321", "10002" },
                    { 3, "bob.smith@example.com", 2, "Smith", "Bob", "Doe", "Johnson", "555-1357", "1357924680", "9012", "555-2468", "10003" }
                });

            migrationBuilder.InsertData(
                table: "CustomerHouses",
                columns: new[] { "CustomerHouseId", "Address", "BuildingArea", "ConnectionNumber", "Coordinates", "CustomerId", "ElectricitySubscriptionNumber", "LandArea", "LandNumber", "PlotNumber", "PropertyType", "RequestType" },
                values: new object[,]
                {
                    { 1, "123 Main St", 150.19999999999999, 789, "40.7128,-74.0060", 1, 101112, 250.5, 456, 123, "Residential", "new" },
                    { 2, "456 Broadway", 300.80000000000001, 101, "40.7214,-74.0052", 2, 131415, 450.19999999999999, 789, 456, "Commercial", "new" },
                    { 3, "789 Elm St", 200.5, 161, "40.7069,-73.9969", 3, 161718, 300.0, 123, 789, "Residential", "Upgrade" }
                });

            migrationBuilder.InsertData(
                table: "WaterOrders",
                columns: new[] { "OrderId", "ContactNumber", "CustomerId", "DeliveryAddress", "OrderDate", "Status" },
                values: new object[,]
                {
                    { 1, "555-1234", 1, "123 Main St", new DateTime(2023, 4, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "555-5678", 2, "456 Broadway", new DateTime(2023, 4, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "555-9012", 3, "789 Elm St", new DateTime(2023, 4, 8, 15, 45, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerHouses",
                keyColumn: "CustomerHouseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerHouses",
                keyColumn: "CustomerHouseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerHouses",
                keyColumn: "CustomerHouseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WaterOrders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WaterOrders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WaterOrders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);
        }
    }
}
