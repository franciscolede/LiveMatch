using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMatch.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeporteRefId = table.Column<int>(type: "int", nullable: true),
                    Estadio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvento = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
