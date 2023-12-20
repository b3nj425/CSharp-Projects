using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingoDefinitivo.Data.Migrations
{
    public partial class BingoDataBaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BingoTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carton1 = table.Column<int>(type: "int", nullable: false),
                    Carton2 = table.Column<int>(type: "int", nullable: false),
                    Carton3 = table.Column<int>(type: "int", nullable: false),
                    Carton4 = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bolilla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeBolilla = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolilla", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BingoTable");

            migrationBuilder.DropTable(
                name: "Bolilla");
        }
    }
}
