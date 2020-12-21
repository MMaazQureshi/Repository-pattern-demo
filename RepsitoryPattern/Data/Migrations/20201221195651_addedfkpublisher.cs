using Microsoft.EntityFrameworkCore.Migrations;

namespace RepsitoryPattern.Data.Migrations
{
    public partial class addedfkpublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_books_PublisherId",
                table: "books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Publishers_PublisherId",
                table: "books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Publishers_PublisherId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_PublisherId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "books");
        }
    }
}
