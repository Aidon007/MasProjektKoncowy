using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasProjektKoncowy.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    OsobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 25, nullable: true),
                    Nazwisko = table.Column<string>(maxLength: 25, nullable: true),
                    Login = table.Column<string>(maxLength: 25, nullable: true),
                    Haslo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.OsobaId);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.OsobaId);
                    table.ForeignKey(
                        name: "FK_Klienci_Osoby_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoby",
                        principalColumn: "OsobaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracowniki",
                columns: table => new
                {
                    OsobaId = table.Column<int>(nullable: false),
                    Numer = table.Column<int>(maxLength: 40, nullable: false),
                    DataZatrudnienia = table.Column<DateTime>(nullable: false),
                    DataZwolnienia = table.Column<DateTime>(nullable: false),
                    Specjalizacja = table.Column<string>(maxLength: 40, nullable: true),
                    Pensja = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracowniki", x => x.OsobaId);
                    table.ForeignKey(
                        name: "FK_Pracowniki_Osoby_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoby",
                        principalColumn: "OsobaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    ZamowienieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cena = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    PlanowyTerminRealizacji = table.Column<DateTime>(nullable: false),
                    TerminZrealizowany = table.Column<DateTime>(nullable: false),
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.ZamowienieId);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Klienci_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Klienci",
                        principalColumn: "OsobaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projekty",
                columns: table => new
                {
                    ProjektId = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: true),
                    Numer = table.Column<int>(maxLength: 50, nullable: false),
                    TypProjektu = table.Column<string>(maxLength: 50, nullable: true),
                    Opis = table.Column<string>(maxLength: 255, nullable: true),
                    OsobaId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    TypBazy = table.Column<string>(maxLength: 50, nullable: true),
                    TypSystemu = table.Column<string>(nullable: true),
                    TypAplikacji = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekty", x => x.ProjektId);
                    table.ForeignKey(
                        name: "FK_Projekty_Pracowniki_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Pracowniki",
                        principalColumn: "OsobaId");
                    table.ForeignKey(
                        name: "FK_Projekty_Zamowienia_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Zamowienia",
                        principalColumn: "ZamowienieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramistaProjekt_asoc",
                columns: table => new
                {
                    ProgramistaProjektId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobaId = table.Column<int>(nullable: false),
                    ProjektId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramistaProjekt_asoc", x => x.ProgramistaProjektId);
                    table.ForeignKey(
                        name: "FK_ProgramistaProjekt_asoc_Pracowniki_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Pracowniki",
                        principalColumn: "OsobaId");
                    table.ForeignKey(
                        name: "FK_ProgramistaProjekt_asoc_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "ProjektId");
                });

            migrationBuilder.CreateTable(
                name: "TesterkoduProjekt_asoc",
                columns: table => new
                {
                    TesterkoduProjektId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobaId = table.Column<int>(nullable: false),
                    ProjektId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesterkoduProjekt_asoc", x => x.TesterkoduProjektId);
                    table.ForeignKey(
                        name: "FK_TesterkoduProjekt_asoc_Pracowniki_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Pracowniki",
                        principalColumn: "OsobaId");
                    table.ForeignKey(
                        name: "FK_TesterkoduProjekt_asoc_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "ProjektId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramistaProjekt_asoc_OsobaId",
                table: "ProgramistaProjekt_asoc",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramistaProjekt_asoc_ProjektId",
                table: "ProgramistaProjekt_asoc",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_OsobaId",
                table: "Projekty",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_TesterkoduProjekt_asoc_OsobaId",
                table: "TesterkoduProjekt_asoc",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_TesterkoduProjekt_asoc_ProjektId",
                table: "TesterkoduProjekt_asoc",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_OsobaId",
                table: "Zamowienia",
                column: "OsobaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramistaProjekt_asoc");

            migrationBuilder.DropTable(
                name: "TesterkoduProjekt_asoc");

            migrationBuilder.DropTable(
                name: "Projekty");

            migrationBuilder.DropTable(
                name: "Pracowniki");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Osoby");
        }
    }
}
