using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class someModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_NutritionId",
                table: "Recipes");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NutritionId",
                table: "Recipes",
                column: "NutritionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_NutritionId",
                table: "Recipes");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NutritionId",
                table: "Recipes",
                column: "NutritionId");
        }
    }
}
