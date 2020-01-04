using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RefactoredRecipeDataAndDroppedValueObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrition_Ingredients_IngredientId",
                table: "Nutrition");

            migrationBuilder.DropIndex(
                name: "IX_Nutrition_IngredientId",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "Type_Name",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "Measurement_Type",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Measurement_Type",
                table: "Nutrition",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Nutrition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "Nutrition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_FoodId",
                table: "Nutrition",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrition_Food_FoodId",
                table: "Nutrition",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrition_Food_FoodId",
                table: "Nutrition");

            migrationBuilder.DropIndex(
                name: "IX_Nutrition_FoodId",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Nutrition",
                newName: "Measurement_Type");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Nutrition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type_Name",
                table: "Nutrition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Measurement_Type",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_IngredientId",
                table: "Nutrition",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrition_Ingredients_IngredientId",
                table: "Nutrition",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
