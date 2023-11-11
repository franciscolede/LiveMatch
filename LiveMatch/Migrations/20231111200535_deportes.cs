using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMatch.Migrations
{
    /// <inheritdoc />
    public partial class deportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DeporteRefId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Deporte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deporte", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DeporteRefId",
                table: "Eventos",
                column: "DeporteRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Deporte_DeporteRefId",
                table: "Eventos",
                column: "DeporteRefId",
                principalTable: "Deporte",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Deporte_DeporteRefId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Deporte");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_DeporteRefId",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "DeporteRefId",
                table: "Eventos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
