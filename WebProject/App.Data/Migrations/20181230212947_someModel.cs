using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class someModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Directions");

            migrationBuilder.AddColumn<int>(
                name: "CookSkill",
                table: "Directions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookSkill",
                table: "Directions");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Directions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
