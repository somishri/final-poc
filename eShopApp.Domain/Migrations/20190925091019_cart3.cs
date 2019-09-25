using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopApp.Domain.Migrations
{
    public partial class cart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderQuantity",
                table: "Carts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderQuantity",
                table: "Carts");
        }
    }
}
