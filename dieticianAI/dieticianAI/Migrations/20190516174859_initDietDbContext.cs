using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dieticianAI.Migrations
{
    public partial class initDietDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RawData = table.Column<string>(nullable: true),
                    FAT_KCAL = table.Column<double>(nullable: false),
                    ENERC_KCAL = table.Column<double>(nullable: false),
                    PROCNT = table.Column<double>(nullable: false),
                    CHOLE = table.Column<double>(nullable: false),
                    CHOCDF = table.Column<double>(nullable: false),
                    SUGAR = table.Column<double>(nullable: false),
                    FIBTG = table.Column<double>(nullable: false),
                    FAT = table.Column<double>(nullable: false),
                    FASAT = table.Column<double>(nullable: false),
                    FATRN = table.Column<double>(nullable: false),
                    WATER = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");
        }
    }
}
