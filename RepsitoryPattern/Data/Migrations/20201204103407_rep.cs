using Microsoft.EntityFrameworkCore.Migrations;

namespace RepsitoryPattern.Data.Migrations
{
    public partial class rep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reputation",
                table: "authors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "authors");
        }
    }
}
