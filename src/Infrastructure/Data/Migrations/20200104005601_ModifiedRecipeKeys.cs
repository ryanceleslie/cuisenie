using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ModifiedRecipeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeEquipment_Equipment_EquipmentId",
                table: "RecipeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeEquipment_Recipes_RecipeId",
                table: "RecipeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedRecipes_Recipes_ChildRecipeId",
                table: "RelatedRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedRecipes",
                table: "RelatedRecipes");

            migrationBuilder.DropIndex(
                name: "IX_RelatedRecipes_ChildRecipeId",
                table: "RelatedRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeEquipment",
                table: "RecipeEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "ChildRecipeId",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "Ready",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RelatedRecipes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "RelatedRecipes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RelatedRecipes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "RelatedRecipes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "RelatedRecipes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentRecipeId1",
                table: "RelatedRecipes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RelatedRecipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RecipeEquipment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "RecipeEquipment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RecipeEquipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId1",
                table: "RecipeEquipment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "RecipeEquipment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "RecipeEquipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RecipeCategories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "RecipeCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "RecipeCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RecipeCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "RecipeCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "RecipeCategories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedRecipes",
                table: "RelatedRecipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeEquipment",
                table: "RecipeEquipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedRecipes_ParentRecipeId",
                table: "RelatedRecipes",
                column: "ParentRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedRecipes_ParentRecipeId1",
                table: "RelatedRecipes",
                column: "ParentRecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeEquipment_EquipmentId1",
                table: "RecipeEquipment",
                column: "EquipmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_CategoryId1",
                table: "RecipeCategories",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Recipes_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId1",
                table: "RecipeCategories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeEquipment_Recipes_EquipmentId",
                table: "RecipeEquipment",
                column: "EquipmentId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeEquipment_Equipment_EquipmentId1",
                table: "RecipeEquipment",
                column: "EquipmentId1",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedRecipes_Recipes_ParentRecipeId1",
                table: "RelatedRecipes",
                column: "ParentRecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Recipes_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId1",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeEquipment_Recipes_EquipmentId",
                table: "RecipeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeEquipment_Equipment_EquipmentId1",
                table: "RecipeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedRecipes_Recipes_ParentRecipeId1",
                table: "RelatedRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedRecipes",
                table: "RelatedRecipes");

            migrationBuilder.DropIndex(
                name: "IX_RelatedRecipes_ParentRecipeId",
                table: "RelatedRecipes");

            migrationBuilder.DropIndex(
                name: "IX_RelatedRecipes_ParentRecipeId1",
                table: "RelatedRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeEquipment",
                table: "RecipeEquipment");

            migrationBuilder.DropIndex(
                name: "IX_RecipeEquipment_EquipmentId1",
                table: "RecipeEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories");

            migrationBuilder.DropIndex(
                name: "IX_RecipeCategories_CategoryId1",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "ParentRecipeId1",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RelatedRecipes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RecipeEquipment");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RecipeEquipment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RecipeEquipment");

            migrationBuilder.DropColumn(
                name: "EquipmentId1",
                table: "RecipeEquipment");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "RecipeEquipment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RecipeEquipment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RecipeCategories");

            migrationBuilder.AddColumn<int>(
                name: "ChildRecipeId",
                table: "RelatedRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Ready",
                table: "Recipes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedRecipes",
                table: "RelatedRecipes",
                columns: new[] { "ParentRecipeId", "ChildRecipeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeEquipment",
                table: "RecipeEquipment",
                columns: new[] { "RecipeId", "EquipmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories",
                columns: new[] { "RecipeId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedRecipes_ChildRecipeId",
                table: "RelatedRecipes",
                column: "ChildRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeEquipment_Equipment_EquipmentId",
                table: "RecipeEquipment",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeEquipment_Recipes_RecipeId",
                table: "RecipeEquipment",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedRecipes_Recipes_ChildRecipeId",
                table: "RelatedRecipes",
                column: "ChildRecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
