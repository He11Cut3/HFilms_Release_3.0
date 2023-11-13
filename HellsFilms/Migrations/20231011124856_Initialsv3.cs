using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HellsFilms.Migrations
{
    public partial class Initialsv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HellsFilmsSerials",
                columns: table => new
                {
                    HellsFilmsSerialID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HellsFilmsSerialIDSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsSerialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsFilmsSerialDate = table.Column<int>(type: "int", nullable: false),
                    HellsFilmsSerialRating = table.Column<double>(type: "float", nullable: false),
                    HellsFilmsSerialPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HellsFilmsSerials", x => x.HellsFilmsSerialID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HellsFilmsSerials");
        }
    }
}
