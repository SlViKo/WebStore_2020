using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.DAL.Migrations
{
    public partial class AddColomns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ProductBrands",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Categories",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Categories");
        }
    }
}
