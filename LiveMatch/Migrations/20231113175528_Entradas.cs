using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMatch.Migrations
{
    /// <inheritdoc />
    public partial class Entradas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Eventos_EventoRefId",
                table: "Entradas");

            migrationBuilder.AlterColumn<int>(
                name: "EventoRefId",
                table: "Entradas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Eventos_EventoRefId",
                table: "Entradas",
                column: "EventoRefId",
                principalTable: "Eventos",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Eventos_EventoRefId",
                table: "Entradas");

            migrationBuilder.AlterColumn<int>(
                name: "EventoRefId",
                table: "Entradas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Eventos_EventoRefId",
                table: "Entradas",
                column: "EventoRefId",
                principalTable: "Eventos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
