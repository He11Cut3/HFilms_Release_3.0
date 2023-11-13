using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HellsFilms.Migrations
{
    public partial class Initialsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HellsFilmsMovieIDFilms",
                table: "HellsFilmsMovies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HellsFilmsMovieIDFilms",
                table: "HellsFilmsMovies");
        }
    }
}
