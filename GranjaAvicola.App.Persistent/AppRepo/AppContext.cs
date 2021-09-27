using Microsoft.EntityFrameworkCore;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public class AppContext : DbContext
    {
        public DbSet<Galpon> Galpon {get;set;}
        public DbSet<Georeferencias> Georeferencias {get; set;}
        public DbSet<Persona> Persona{get;set;}
        public DbSet<Rol> Rol{get;set;}
        public DbSet<Registro> Registro{get;set;}
        public DbSet<Diagnostico> Diagnostico{get;set;}

        //TODO: Faltan las implementaciones de las entidades registros y Diagnostico 

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if(!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder
                /*
                [Angel/Diseñador de Software] 17/09/2021
                Aqui el DataSource es el nombre de la base de datos local recuerden cambiarlo siempre que vayan a realizar pruebas localmente
                    Data Sources de cada maquina:
                        Juan Pablo : [Por escribir]  
                        Juan Camilo : [Por escribir]
                        Miguel : (localdb)\\MSSQLLocalDB
                        Angel : LAPTOP-VPO7HRDD\\SQLEXPRESS
                */
                .UseSqlServer("Initial Catalog = GranjaAvicola.Data; Data Source=(localdb)\\MSSQLLocalDB; Integrated Security=true");
            }
        }
        
        /*
        [Angel/Diseñador de Software] 17/09/2021
        Esta sentencia es para configurar el modelo que se está creando por ahora solo dejar todas las entidades con un HasNokey() para que
        No genere errores el Entity Framework :)
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Galpon>().HasNoKey();
            modelBuilder.Entity<Georeferencias>().HasNoKey();
            modelBuilder.Entity<Persona>().HasNoKey();
            modelBuilder.Entity<Registro>().HasNoKey();
            modelBuilder.Entity<Rol>().HasNoKey();
            modelBuilder.Entity<Diagnostico>().HasNoKey();
            //TODO: Generar las configuraciones para las entidades faltantes (Registros, Rol y Diagnostico)
        }
    }
}