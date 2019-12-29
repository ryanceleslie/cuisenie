using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddRelatedRecipesProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeId",
                table: "Recipes",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Recipes_RecipeId",
                table: "Recipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipes_RecipeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Recipes");
        }
    }
}
