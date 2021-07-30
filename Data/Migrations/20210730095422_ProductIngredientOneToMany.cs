using Microsoft.EntityFrameworkCore.Migrations;

namespace PadariaTech.Data.Migrations
{
    public partial class ProductIngredientOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Products_IdProduct",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IdProduct",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Ingredients",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProductId",
                table: "Ingredients",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Products_ProductId",
                table: "Ingredients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Products_ProductId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_ProductId",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Ingredients",
                newName: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IdProduct",
                table: "Ingredients",
                column: "IdProduct",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Products_IdProduct",
                table: "Ingredients",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
