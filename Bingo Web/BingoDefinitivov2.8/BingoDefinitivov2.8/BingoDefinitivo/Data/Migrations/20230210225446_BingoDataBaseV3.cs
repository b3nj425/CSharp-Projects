using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingoDefinitivo.Data.Migrations
{
    public partial class BingoDataBaseV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroDeBolilla",
                table: "Bolilla",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BolillaListViewModelId",
                table: "Bolilla",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carton4",
                table: "BingoTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Carton3",
                table: "BingoTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Carton2",
                table: "BingoTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Carton1",
                table: "BingoTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ListaBolillaEnJuego",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaBolillaEnJuego", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolilla_BolillaListViewModelId",
                table: "Bolilla",
                column: "BolillaListViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bolilla_ListaBolillaEnJuego_BolillaListViewModelId",
                table: "Bolilla",
                column: "BolillaListViewModelId",
                principalTable: "ListaBolillaEnJuego",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bolilla_ListaBolillaEnJuego_BolillaListViewModelId",
                table: "Bolilla");

            migrationBuilder.DropTable(
                name: "ListaBolillaEnJuego");

            migrationBuilder.DropIndex(
                name: "IX_Bolilla_BolillaListViewModelId",
                table: "Bolilla");

            migrationBuilder.DropColumn(
                name: "BolillaListViewModelId",
                table: "Bolilla");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroDeBolilla",
                table: "Bolilla",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carton4",
                table: "BingoTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carton3",
                table: "BingoTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carton2",
                table: "BingoTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carton1",
                table: "BingoTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
