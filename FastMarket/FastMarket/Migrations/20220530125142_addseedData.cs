using Microsoft.EntityFrameworkCore.Migrations;

namespace FastMarket.Migrations
{
    public partial class addseedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[,]
                {
                    { 1, "c1 Details", "c1" },
                    { 2, "c1 Details", "c1" },
                    { 3, "c1 Details", "c1" },
                    { 4, "c1 Details", "c1" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 30, "Description1", "Product1", 100m },
                    { 2, 40, "Description2", "Product2", 350m },
                    { 3, 50, "Description3", "Product3", 200m },
                    { 4, 60, "Description4", "Product4", 230m },
                    { 5, 70, "Description5", "Product5", 105m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
