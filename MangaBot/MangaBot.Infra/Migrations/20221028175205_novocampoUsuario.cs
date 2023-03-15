using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaBot.Infra.Migrations
{
    public partial class novocampoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "apikey",
                table: "tbUsuario",
                type: "string",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apikey",
                table: "tbUsuario");
        }
    }
}
