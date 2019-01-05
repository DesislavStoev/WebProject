using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "Recipes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuType",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
