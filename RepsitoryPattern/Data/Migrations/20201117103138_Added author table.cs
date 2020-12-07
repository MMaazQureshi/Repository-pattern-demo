using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepsitoryPattern.Data.Migrations
{
    public partial class Addedauthortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_authors_AuthorId",
                table: "books",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_AuthorId",
                table: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropIndex(
                name: "IX_books_AuthorId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "books");
        }
    }
}
