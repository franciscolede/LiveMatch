using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMatch.Migrations
{
    /// <inheritdoc />
    public partial class vinculoEventoConEstadio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estadio",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "EstadioRefId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EstadioRefId",
                table: "Eventos",
                column: "EstadioRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Estadio_EstadioRefId",
                table: "Eventos",
                column: "EstadioRefId",
                principalTable: "Estadio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Estadio_EstadioRefId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_EstadioRefId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EstadioRefId",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "Estadio",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
