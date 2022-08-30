using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Infrastructure.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeImages_RecipeId",
                table: "RecipeImages");

            migrationBuilder.DropIndex(
                name: "IX_IngredientImages_IngredientId",
                table: "IngredientImages");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImages_RecipeId",
                table: "RecipeImages",
                column: "RecipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientImages_IngredientId",
                table: "IngredientImages",
                column: "IngredientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeImages_RecipeId",
                table: "RecipeImages");

            migrationBuilder.DropIndex(
                name: "IX_IngredientImages_IngredientId",
                table: "IngredientImages");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImages_RecipeId",
                table: "RecipeImages",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientImages_IngredientId",
                table: "IngredientImages",
                column: "IngredientId");
        }
    }
}
