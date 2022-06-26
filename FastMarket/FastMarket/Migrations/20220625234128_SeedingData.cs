using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastMarket.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.ProductId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesProducts",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesProducts", x => new { x.CategoriesId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[,]
                {
                    { 1, "Beauty Category contain multiple product like Blushes,Foundation,Gloss....", "Beauty" },
                    { 2, "Clothes Category contain multiple product like jeens,T-shirt,dress....", "Clothes" },
                    { 3, "Mobiles Category contain multiple product like IPhones,Samsung,Nokia....", "Mobiles" },
                    { 4, "Computers & accessories Category contain multiple product like PC,Labtop,Headphones....", "Computers & accessories" },
                    { 5, "Furniture Category contain multiple product like Beds ,Beds Covers, Sofa", "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Description", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { 18, 50, "YITAHOME 6 Pieces Patio Furniture Set, Outdoor Conversation Set, Outside Sectional Sofa PE Rattan Wicker Set with Table and Cushion for Porch Lawn Garden and Poolside, Gray Gradient", "https://faststorestorage.blob.core.windows.net/images/R(18).jpg", "YITAHOME 6 Pieces Patio Furniture Set", 456m },
                    { 17, 50, "HP Chromebook 14-inch HD Touchscreen Laptop, Intel Celeron N4000, 4 GB RAM, 32 GB eMMC, Chrome (14a-na0080nr, Forest Teal)", "https://faststorestorage.blob.core.windows.net/images/R(17).jpg", "HP Chromebook 14-inch HD Touchscreen Laptop", 734m },
                    { 16, 50, "New Microsoft Surface Go 2 - 10.5 Touch-Screen - Intel Pentium - 4GB Memory - 64GB - Wifi - Platinum (Latest Model)", "https://faststorestorage.blob.core.windows.net/images/R(16).jpg", "Touch-Screen - Intel Pentium ", 345m },
                    { 15, 50, "Newest HP Pavilion Business Laptop, 15.6 Full HD Display, 11th Gen Intel i7-1165G7(Up to 4.7GHz), 16GB RAM, 1TB PCIe SSD, Intel Iris Xe Graphics, Backlit KB, Fingerprint, Bluetooth, Windows 11 Pro", "https://faststorestorage.blob.core.windows.net/images/R(15).jpg", "Business Laptop", 200m },
                    { 14, 50, "Nokia XR20 5G | Android 11 | Unlocked Smartphone | Dual SIM | US Version | 6/128GB | 6.67-Inch Screen | 48MP Dual Camera | Granite", "https://faststorestorage.blob.core.windows.net/images/R(14).jpg", "Nokia XR20 5G", 432m },
                    { 13, 50, "SAMSUNG Galaxy S22 Cell Phone, Factory Unlocked Android Smartphone, 256GB, 8K Camera & Video, Brightest Display Screen, Long Battery Life, Fast 4nm Processor, US Version, Green", "https://faststorestorage.blob.core.windows.net/images/R(13).jpg", "SAMSUNG Galaxy S22", 543m },
                    { 12, 50, "Apple iPhone 13 Pro Max (256 GB, Alpine Green) [Locked] + Carrier Subscription", "https://faststorestorage.blob.core.windows.net/images/R(12).jpg", "Apple iPhone 13 Pro Max ", 333m },
                    { 11, 50, "5 Pack Men’s Active Quick Dry Crew Neck T Shirts | Athletic Running Gym Workout Short Sleeve Tee Tops Bulk", "https://faststorestorage.blob.core.windows.net/images/R(11).jpg", "T Shirts", 418m },
                    { 10, 50, "Muslim Dresses for Women, One-Piece Long Sleeve Islamic Prayer Dress & Prayer Rug & Beads, Islamic Set", "https://faststorestorage.blob.core.windows.net/images/R(10).jpg", "Muslim Dresses for Women", 722m },
                    { 8, 50, "Simple Joys by Carter's Girls and Toddlers' 4-Piece Pajama Set (Cotton Top & Fleece Bottom)", "https://faststorestorage.blob.core.windows.net/images/R(8).jpg", "Bejamas", 432m },
                    { 19, 50, "LOKATSE HOME Outdoor 2 Piece Patio Chairs Conversation Set Metal Frame Furniture with Cushion, Blue", "https://faststorestorage.blob.core.windows.net/images/R(19).jpg", "Chairs Conversation Set Metal Frame Furniture", 254m },
                    { 7, 50, "Makeup Remover Cleansing Face Wipes, Daily Cleansing Facial Towelettes to Remove Waterproof Makeup and Mascara, Alcohol-Free, Value Twin Pack, 25 Count", "https://faststorestorage.blob.core.windows.net/images/R(7).jpg", "Makeup Remover", 200m },
                    { 6, 40, "BESTOPE PRO Premium Synthetic Contour Concealers Foundation Powder Eye Shadows Makeup Brushes with Champagne Gold Conical Handle, 20 Count", "https://faststorestorage.blob.core.windows.net/images/R(6).jpg", "Brushes ", 350m },
                    { 5, 30, "UCANBE 18 Colors Aromas Nude Eyeshadow Palette Long Lasting Multi Reflective Shimmer Matte Glitter Pressed Pearls Eye Shadow Makeup Pallet", "https://faststorestorage.blob.core.windows.net/images/R(1).jpg", "Eyeshadow", 100m },
                    { 4, 60, "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer", "https://faststorestorage.blob.core.windows.net/images/R(4).jpg", "Concealer ", 35.00m },
                    { 3, 250, "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", "https://faststorestorage.blob.core.windows.net/images/R(3).jpg", "Foundation ", 50.00m },
                    { 2, 120, "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", "https://faststorestorage.blob.core.windows.net/images/R(5).jpg", "Blushes", 20.00m },
                    { 1, 150, "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", "https://faststorestorage.blob.core.windows.net/images/R.jpg", "Liner & Colossal Kajal", 15.5m },
                    { 9, 50, "Moon and Back by Hanna Andersson Kids' Organic Holiday Family Matching 2 Piece Pajama Set", "https://faststorestorage.blob.core.windows.net/images/R(9).jpg", "2 Piece Pajama Set", 321m },
                    { 20, 50, "DHP Dakota Upholstered Platform Bed with Underbed Storage Drawers and Diamond Button Tufted Headboard and Footboard, No Box Spring Needed, Queen, White Faux Leather", "https://faststorestorage.blob.core.windows.net/images/R(20).jpg", "Bed", 512m }
                });

            migrationBuilder.InsertData(
                table: "CategoriesProducts",
                columns: new[] { "CategoriesId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 18 },
                    { 4, 17 },
                    { 4, 16 },
                    { 4, 15 },
                    { 3, 14 },
                    { 3, 13 },
                    { 3, 12 },
                    { 2, 11 },
                    { 2, 10 },
                    { 2, 9 },
                    { 2, 8 },
                    { 1, 7 },
                    { 1, 6 },
                    { 1, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 5, 19 },
                    { 5, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId",
                table: "CartProducts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesProducts_ProductId",
                table: "CategoriesProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "CategoriesProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
