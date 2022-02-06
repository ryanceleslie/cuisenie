using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedListOfListsForRecipeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalUrl",
                table: "Instructions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructionSetId",
                table: "Instructions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Instructions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Instructions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientSetId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Food",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientSets_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructionSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    ExternalUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructionSets_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_InstructionSetId",
                table: "Instructions",
                column: "InstructionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientSetId",
                table: "Ingredients",
                column: "IngredientSetId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSets_RecipeId",
                table: "IngredientSets",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructionSets_RecipeId",
                table: "InstructionSets",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientSets_IngredientSetId",
                table: "Ingredients",
                column: "IngredientSetId",
                principalTable: "IngredientSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_InstructionSets_InstructionSetId",
                table: "Instructions",
                column: "InstructionSetId",
                principalTable: "InstructionSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientSets_IngredientSetId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_InstructionSets_InstructionSetId",
                table: "Instructions");

            migrationBuilder.DropTable(
                name: "IngredientSets");

            migrationBuilder.DropTable(
                name: "InstructionSets");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_InstructionSetId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientSetId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ExternalUrl",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "InstructionSetId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "IngredientSetId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Food");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Instructions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
