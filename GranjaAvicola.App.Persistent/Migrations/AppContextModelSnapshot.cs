﻿// <auto-generated />
using GranjaAvicola.App.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GranjaAvicola.App.Persistence.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GranjaAvicola.App.Domain.Galpon", b =>
                {
                    b.Property<string>("FechaIngreso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaSalida")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.ToTable("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}
