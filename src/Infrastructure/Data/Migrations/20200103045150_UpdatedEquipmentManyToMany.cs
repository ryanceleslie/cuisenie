using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdatedEquipmentManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Recipes_RecipeId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_RecipeId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Equipment");

            migrationBuilder.CreateTable(
                name: "RecipeEquipment",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeEquipment", x => new { x.RecipeId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_RecipeEquipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeEquipment_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeEquipment_EquipmentId",
                table: "RecipeEquipment",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeEquipment");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RecipeId",
                table: "Equipment",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Recipes_RecipeId",
                table: "Equipment",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
