using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Infrastructure.Migrations
{
    public partial class UpdateDatabaseModelRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "RecipeIngredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "RecipeWithRecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeWithRecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeWithRecipeIngredients_RecipeIngredients_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeWithRecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeWithRecipeIngredients_RecipeId",
                table: "RecipeWithRecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeWithRecipeIngredients_RecipeIngredientId",
                table: "RecipeWithRecipeIngredients",
                column: "RecipeIngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeWithRecipeIngredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Ingredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId",
                table: "RecipeIngredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
