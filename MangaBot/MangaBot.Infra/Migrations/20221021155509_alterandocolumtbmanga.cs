using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaBot.Infra.Migrations
{
    public partial class alterandocolumtbmanga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoCapitulo",
                table: "tbManga",
                newName: "TotaldeCapitulos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotaldeCapitulos",
                table: "tbManga",
                newName: "UltimoCapitulo");
        }
    }
}
