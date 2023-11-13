using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMatch.Migrations
{
    /// <inheritdoc />
    public partial class EventosEntradaList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Eventos_EntradaRefId",
                table: "Entradas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_EntradaRefId",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "EntradaRefId",
                table: "Entradas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntradaRefId",
                table: "Entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_EntradaRefId",
                table: "Entradas",
                column: "EntradaRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Eventos_EntradaRefId",
                table: "Entradas",
                column: "EntradaRefId",
                principalTable: "Eventos",
                principalColumn: "ID");
        }
    }
}
