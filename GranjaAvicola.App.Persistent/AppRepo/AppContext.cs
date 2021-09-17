using Microsoft.EntityFrameworkCore;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public class AppContext : DbContext
    {
        public DbSet<Galpon> Galpon {get;set;}
        public DbSet<Georeferencias> Georeferencias {get; set;}
        public DbSet<Persona> Persona{get;set;}

        //TODO: Faltan las implementaciones de las entidades registros y Diagnostico 

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if(!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder
                /*
                Aqui el DataSource es el nombre de la base de datos local recuerden cambiarlo siempre que vayan a realizar pruebas localmente
                    Data Sources de cada maquina:
                        Juan Pablo : [Por escribir]  
                        Juan Camilo : [Por escribir]
                        Miguel : (localdb)\\MSSQLLocalDB
                        Angel : LAPTOP-VPO7HRDD\\SQLEXPRESS
                */
                .UseSqlServer("Initial Catalog = ParkingApp.Data; Data Source=LAPTOP-VPO7HRDD\\SQLEXPRESS; Integrated Security=true");
            }
        }
    }
}