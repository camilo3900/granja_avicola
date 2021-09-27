﻿// <auto-generated />
using GranjaAvicola.App.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GranjaAvicola.App.Persistence.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210918144901_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GranjaAvicola.App.Domain.Diagnostico", b =>
                {
                    b.Property<string>("DiagnosticoVet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Diagnstico")
                        .HasColumnType("int");

                    b.Property<int>("ID_Registro")
                        .HasColumnType("int");

                    b.Property<int>("ID_Sugerencia")
                        .HasColumnType("int");

                    b.Property<int>("ID_VeterinarioCargo")
                        .HasColumnType("int");

                    b.Property<string>("Sugerencia")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("GranjaAvicola.App.Domain.Galpon", b =>
                {
                    b.Property<System.DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<System.DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("Georeferencia")
                        .HasColumnType("int");

                    b.Property<int>("ID_Galpon")
                        .HasColumnType("int");

                    b.Property<int>("ID_OperarioCargo")
                        .HasColumnType("int");

                    b.Property<int>("ID_VeterinarioCargo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroAnimales")
                        .HasColumnType("int");

                    b.ToTable("Galpon");
                });

            modelBuilder.Entity("GranjaAvicola.App.Domain.Georeferencias", b =>
                {
                    b.Property<int>("ID_GeoRef")
                        .HasColumnType("int");

                    b.Property<double>("altitud")
                        .HasColumnType("float");

                    b.Property<double>("latitud")
                        .HasColumnType("float");

                    b.ToTable("Georeferencias");
                });

            modelBuilder.Entity("GranjaAvicola.App.Domain.Persona", b =>
                {
                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("ID_Persona")
                        .HasColumnType("int");

                    b.Property<int>("ID_Rol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("GranjaAvicola.App.Domain.Registro", b =>
                {
                    b.Property<double>("Agua")
                        .HasColumnType("float");

                    b.Property<double>("Alimento")
                        .HasColumnType("float");

                    b.Property<System.DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("GallinasEnfermas")
                        .HasColumnType("int");

                    b.Property<int>("ID_Galpon")
                        .HasColumnType("int");

                    b.Property<int>("ID_Registro")
                        .HasColumnType("int");

                    b.Property<int>("ID_Trabajador")
                        .HasColumnType("int");

                    b.Property<int>("PromedioHuevos")
                        .HasColumnType("int");

                    b.Property<double>("Temperatura")
                        .HasColumnType("float");

                    b.ToTable("Registro");
                });

            modelBuilder.Entity("GranjaAvicola.App.Domain.Rol", b =>
                {
                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Rol")
                        .HasColumnType("int");

                    b.ToTable("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}