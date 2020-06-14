using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw14_PowtorkaDoKolokwium.Migrations
{
    public partial class CreatingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyrobu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 100, nullable: true),
                    CenaZaSzt = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobyCukiernicze", x => x.IdWyrobu);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: true),
                    Uwagi = table.Column<string>(maxLength: 100, nullable: true),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                });

            migrationBuilder.CreateTable(
                name: "Zamówienia_WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyrobu = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamówienia_WyrobyCukiernicze", x => new { x.IdWyrobu, x.IdZamowienia });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "WyrobyCukiernicze");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Zamówienia_WyrobyCukiernicze");
        }
    }
}
