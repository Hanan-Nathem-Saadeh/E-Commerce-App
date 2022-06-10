using Microsoft.EntityFrameworkCore.Migrations;

namespace FastMarket.Migrations
{
    public partial class addURIprobarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Products");
        }
    }
}
