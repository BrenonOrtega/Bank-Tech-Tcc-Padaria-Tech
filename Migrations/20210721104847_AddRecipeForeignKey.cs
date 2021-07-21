using Microsoft.EntityFrameworkCore.Migrations;

namespace PadariaTech.Migrations
{
    public partial class AddRecipeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Products_IdBakedProduct",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IdBakedProduct",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IdBakedProduct",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "IdRecipe",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdRecipe",
                table: "Products",
                column: "IdRecipe",
                unique: true,
                filter: "[IdRecipe] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Recipes_IdRecipe",
                table: "Products",
                column: "IdRecipe",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Recipes_IdRecipe",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdRecipe",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdRecipe",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "IdBakedProduct",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IdBakedProduct",
                table: "Recipes",
                column: "IdBakedProduct",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Products_IdBakedProduct",
                table: "Recipes",
                column: "IdBakedProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
