using Microsoft.EntityFrameworkCore.Migrations;

namespace PadariaTech.Data.Migrations
{
    public partial class FixBakedProduct_RecipeCardinality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Products_BakedProductId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_BakedProductId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "BakedProductId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecipeId",
                table: "Products",
                column: "RecipeId",
                unique: true,
                filter: "[RecipeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Recipes_RecipeId",
                table: "Products",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Recipes_RecipeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RecipeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BakedProductId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_BakedProductId",
                table: "Recipes",
                column: "BakedProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Products_BakedProductId",
                table: "Recipes",
                column: "BakedProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
