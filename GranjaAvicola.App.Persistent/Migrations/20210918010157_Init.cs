using Microsoft.EntityFrameworkCore.Migrations;

namespace GranjaAvicola.App.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galpon",
                columns: table => new
                {
                    ID_Galpon = table.Column<int>(type: "int", nullable: false),
                    Georeferencia = table.Column<int>(type: "int", nullable: false),
                    ID_OperarioCargo = table.Column<int>(type: "int", nullable: false),
                    ID_VeterinarioCargo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroAnimales = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaSalida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Georeferencias",
                columns: table => new
                {
                    ID_GeoRef = table.Column<int>(type: "int", nullable: false),
                    latitud = table.Column<double>(type: "float", nullable: false),
                    altitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galpon");

            migrationBuilder.DropTable(
                name: "Georeferencias");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
