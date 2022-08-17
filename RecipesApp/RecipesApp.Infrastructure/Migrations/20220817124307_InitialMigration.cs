using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    ServingTime = table.Column<int>(type: "int", nullable: false),
                    Servings = table.Column<float>(type: "real", nullable: false),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    Fats = table.Column<float>(type: "real", nullable: false),
                    Carbs = table.Column<float>(type: "real", nullable: false),
                    Proteins = table.Column<float>(type: "real", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    Fats = table.Column<float>(type: "real", nullable: false),
                    Carbs = table.Column<float>(type: "real", nullable: false),
                    Proteins = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    Fats = table.Column<float>(type: "real", nullable: false),
                    Carbs = table.Column<float>(type: "real", nullable: false),
                    Proteins = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlans_Recipes_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealPlans_Recipes_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealPlans_Recipes_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_BreakfastId",
                table: "MealPlans",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_DinnerId",
                table: "MealPlans",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_LunchId",
                table: "MealPlans",
                column: "LunchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
