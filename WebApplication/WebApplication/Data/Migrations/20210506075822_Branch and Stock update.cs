using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympia_Library.Data.Migrations
{
    public partial class BranchandStockupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Branches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Branches");
        }
    }
}
