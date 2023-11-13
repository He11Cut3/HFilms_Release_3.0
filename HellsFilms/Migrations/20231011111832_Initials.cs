using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HellsFilms.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HellsFilmsMovieDescription",
                table: "HellsFilmsMovies");

            migrationBuilder.DropColumn(
                name: "HellsFilmsMovieVideo",
                table: "HellsFilmsMovies");

            migrationBuilder.AlterColumn<string>(
                name: "HellsFilmsMoviePhoto",
                table: "HellsFilmsMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HellsFilmsMovieDate",
                table: "HellsFilmsMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "HellsFilmsMovieRating",
                table: "HellsFilmsMovies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HellsFilmsMovieDate",
                table: "HellsFilmsMovies");

            migrationBuilder.DropColumn(
                name: "HellsFilmsMovieRating",
                table: "HellsFilmsMovies");

            migrationBuilder.AlterColumn<byte[]>(
                name: "HellsFilmsMoviePhoto",
                table: "HellsFilmsMovies",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HellsFilmsMovieDescription",
                table: "HellsFilmsMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "HellsFilmsMovieVideo",
                table: "HellsFilmsMovies",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
