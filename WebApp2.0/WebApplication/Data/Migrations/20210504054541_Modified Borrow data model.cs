using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympia_Library.Data.Migrations
{
    public partial class ModifiedBorrowdatamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrows_BorrowId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BorrowId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Borrows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "Borrows",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BooksBookId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_BooksBookId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "Borrows");

            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowId",
                table: "Books",
                column: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrows_BorrowId",
                table: "Books",
                column: "BorrowId",
                principalTable: "Borrows",
                principalColumn: "BorrowId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
