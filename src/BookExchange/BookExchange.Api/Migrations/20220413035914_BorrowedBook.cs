using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookExchange.Api.Migrations
{
    public partial class BorrowedBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Books_BookId1",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Users_BorrowerId",
                table: "BorrowedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBooks_BookId1",
                table: "BorrowedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBooks_BorrowerId",
                table: "BorrowedBooks");

            migrationBuilder.RenameColumn(
                name: "BookId1",
                table: "BorrowedBooks",
                newName: "LenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LenderId",
                table: "BorrowedBooks",
                newName: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BookId1",
                table: "BorrowedBooks",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BorrowerId",
                table: "BorrowedBooks",
                column: "BorrowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Books_BookId1",
                table: "BorrowedBooks",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Users_BorrowerId",
                table: "BorrowedBooks",
                column: "BorrowerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
