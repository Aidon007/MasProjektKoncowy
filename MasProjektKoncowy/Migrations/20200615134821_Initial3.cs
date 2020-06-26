using Microsoft.EntityFrameworkCore.Migrations;

namespace MasProjektKoncowy.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramistaProjekt_asoc_Pracowniki_OsobaId",
                table: "ProgramistaProjekt_asoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramistaProjekt_asoc_Projekty_ProjektId",
                table: "ProgramistaProjekt_asoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramistaProjekt_asoc",
                table: "ProgramistaProjekt_asoc");

            migrationBuilder.RenameTable(
                name: "ProgramistaProjekt_asoc",
                newName: "ProgProjectAsoc");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramistaProjekt_asoc_ProjektId",
                table: "ProgProjectAsoc",
                newName: "IX_ProgProjectAsoc_ProjektId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramistaProjekt_asoc_OsobaId",
                table: "ProgProjectAsoc",
                newName: "IX_ProgProjectAsoc_OsobaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgProjectAsoc",
                table: "ProgProjectAsoc",
                column: "ProgramistaProjektId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgProjectAsoc_Pracowniki_OsobaId",
                table: "ProgProjectAsoc",
                column: "OsobaId",
                principalTable: "Pracowniki",
                principalColumn: "OsobaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgProjectAsoc_Projekty_ProjektId",
                table: "ProgProjectAsoc",
                column: "ProjektId",
                principalTable: "Projekty",
                principalColumn: "ProjektId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgProjectAsoc_Pracowniki_OsobaId",
                table: "ProgProjectAsoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgProjectAsoc_Projekty_ProjektId",
                table: "ProgProjectAsoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgProjectAsoc",
                table: "ProgProjectAsoc");

            migrationBuilder.RenameTable(
                name: "ProgProjectAsoc",
                newName: "ProgramistaProjekt_asoc");

            migrationBuilder.RenameIndex(
                name: "IX_ProgProjectAsoc_ProjektId",
                table: "ProgramistaProjekt_asoc",
                newName: "IX_ProgramistaProjekt_asoc_ProjektId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgProjectAsoc_OsobaId",
                table: "ProgramistaProjekt_asoc",
                newName: "IX_ProgramistaProjekt_asoc_OsobaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramistaProjekt_asoc",
                table: "ProgramistaProjekt_asoc",
                column: "ProgramistaProjektId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramistaProjekt_asoc_Pracowniki_OsobaId",
                table: "ProgramistaProjekt_asoc",
                column: "OsobaId",
                principalTable: "Pracowniki",
                principalColumn: "OsobaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramistaProjekt_asoc_Projekty_ProjektId",
                table: "ProgramistaProjekt_asoc",
                column: "ProjektId",
                principalTable: "Projekty",
                principalColumn: "ProjektId");
        }
    }
}
