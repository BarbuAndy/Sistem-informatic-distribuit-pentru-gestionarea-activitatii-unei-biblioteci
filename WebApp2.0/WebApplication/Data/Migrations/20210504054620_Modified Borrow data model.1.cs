using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympia_Library.Data.Migrations
{
    public partial class ModifiedBorrowdatamodel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BooksBookId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_BooksBookId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "Borrows");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Borrows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Borrows");

            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "Borrows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BooksBookId",
                table: "Borrows",
                column: "BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BooksBookId",
                table: "Borrows",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
