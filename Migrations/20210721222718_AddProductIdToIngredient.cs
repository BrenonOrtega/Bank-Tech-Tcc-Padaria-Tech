using Microsoft.EntityFrameworkCore.Migrations;

namespace PadariaTech.Migrations
{
    public partial class AddProductIdToIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Portion",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IdProduct",
                table: "Ingredients",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Products_IdProduct",
                table: "Ingredients",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Products_IdProduct",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IdProduct",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Portion",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Ingredients");
        }
    }
}
