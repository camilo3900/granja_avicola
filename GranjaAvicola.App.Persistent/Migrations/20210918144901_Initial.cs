using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GranjaAvicola.App.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    ID_Diagnstico = table.Column<int>(type: "int", nullable: false),
                    ID_Sugerencia = table.Column<int>(type: "int", nullable: false),
                    ID_VeterinarioCargo = table.Column<int>(type: "int", nullable: false),
                    ID_Registro = table.Column<int>(type: "int", nullable: false),
                    DiagnosticoVet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sugerencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

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
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ID_Persona = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    ID_Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    ID_Registro = table.Column<int>(type: "int", nullable: false),
                    ID_Galpon = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Agua = table.Column<double>(type: "float", nullable: false),
                    Alimento = table.Column<double>(type: "float", nullable: false),
                    PromedioHuevos = table.Column<int>(type: "int", nullable: false),
                    GallinasEnfermas = table.Column<int>(type: "int", nullable: false),
                    ID_Trabajador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    ID_Rol = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Galpon");

            migrationBuilder.DropTable(
                name: "Georeferencias");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
