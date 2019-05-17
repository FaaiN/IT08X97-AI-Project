using Microsoft.EntityFrameworkCore.Migrations;

namespace dieticianAI.Migrations
{
    public partial class AddRecipeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeId",
                table: "FoodItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "FoodItems");
        }
    }
}
