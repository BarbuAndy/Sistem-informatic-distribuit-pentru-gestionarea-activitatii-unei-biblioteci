using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympia_Library.Data.Migrations
{
    public partial class AddedGenreImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Genre",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Genre");
        }
    }
}
