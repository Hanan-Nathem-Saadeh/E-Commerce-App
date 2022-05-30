using Microsoft.EntityFrameworkCore.Migrations;

namespace FastMarket.Migrations
{
    public partial class addseedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "Name" },
                values: new object[] { "Beauty Category contain multiple product like Blushes,Foundation,Gloss....", "Beauty" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "Name" },
                values: new object[] { "Clothes Category contain multiple product like jeens,T-shirt,dress....", "Clothes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Details", "Name" },
                values: new object[] { "Mobiles Category contain multiple product like IPhones,Samsung,Nokia....", "Mobiles" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Details", "Name" },
                values: new object[] { "Computers & accessories Category contain multiple product like PC,Labtop,Headphones....", "Computers & accessories" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[,]
                {
                    { 5, "TV & Home Entertainmen Category contain multiple product like DishTV HD,Samsung TV, LG", "TV & Home Entertainment" },
                    { 6, "Furniture Category contain multiple product like Beds ,Beds Covers, Sofa", "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesProducts",
                columns: new[] { "CategoriesId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 150, "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", "Liner & Colossal Kajal", 15.5m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 120, "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", "Blushes", 20.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 250, "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", "Foundation ", 50.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer", "Concealer ", 35.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 30, "Description1", "Product1", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 8, 60, "Description4", "Product4", 230m },
                    { 7, 50, "Description3", "Product3", 200m },
                    { 6, 40, "Description2", "Product2", 350m },
                    { 10, 70, "Description10", "Product10", 105m },
                    { 9, 70, "Description5", "Product5", 105m }
                });

            migrationBuilder.InsertData(
                table: "CategoriesProducts",
                columns: new[] { "CategoriesId", "ProductId" },
                values: new object[,]
                {
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 5, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "CategoriesProducts",
                keyColumns: new[] { "CategoriesId", "ProductId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "Name" },
                values: new object[] { "c1 Details", "c1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "Name" },
                values: new object[] { "c1 Details", "c1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Details", "Name" },
                values: new object[] { "c1 Details", "c1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Details", "Name" },
                values: new object[] { "c1 Details", "c1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 30, "Description1", "Product1", 100m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 40, "Description2", "Product2", 350m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 50, "Description3", "Product3", 200m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Description4", "Product4", 230m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "Description", "Name", "Price" },
                values: new object[] { 70, "Description5", "Product5", 105m });
        }
    }
}
