using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HellsFilms.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HellsFilmsMovies",
                columns: table => new
                {
                    HellsFilmsMovieID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HellsFilmsMovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsMovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsMoviePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HellsFilmsMovieVideo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HellsFilmsMovies", x => x.HellsFilmsMovieID);
                });

            migrationBuilder.CreateTable(
                name: "HellsFilmsTags",
                columns: table => new
                {
                    HellsFilmsTagID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HellsFilmsTagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsTagSlug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HellsFilmsTags", x => x.HellsFilmsTagID);
                });

            migrationBuilder.CreateTable(
                name: "HellsFilmsBlogs",
                columns: table => new
                {
                    HellsFilmsBlogID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HellsFilmsBlogName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsBlogDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsBlogPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HellsFilmsBlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsTagID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HellsFilmsBlogs", x => x.HellsFilmsBlogID);
                    table.ForeignKey(
                        name: "FK_HellsFilmsBlogs_HellsFilmsTags_HellsFilmsTagID",
                        column: x => x.HellsFilmsTagID,
                        principalTable: "HellsFilmsTags",
                        principalColumn: "HellsFilmsTagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HellsFilmsBlogs_HellsFilmsTagID",
                table: "HellsFilmsBlogs",
                column: "HellsFilmsTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HellsFilmsBlogs");

            migrationBuilder.DropTable(
                name: "HellsFilmsMovies");

            migrationBuilder.DropTable(
                name: "HellsFilmsTags");
        }
    }
}
