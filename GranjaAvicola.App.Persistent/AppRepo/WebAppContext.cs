using Microsoft.EntityFrameworkCore;
using GranjaAvicola.App.Domain;
using System.Collections;

namespace GranjaAvicola.App.Persistent
{
    public class WebAppContext : DbContext
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
                /*
                [Angel/Diseñador de Software] 17/09/2021
                Aqui el DataSource es el nombre de la base de datos local recuerden cambiarlo siempre que vayan a realizar pruebas localmente
                    Data Sources de cada maquina:
                        Juan Pablo : [Por escribir]  
                        Juan Camilo : [Por escribir]
                        Miguel : (localdb)\\MSSQLLocalDB
                        Angel : LAPTOP-VPO7HRDD\\SQLEXPRESS
                */
               try
               {
                   OptionsBuilder.UseSqlServer("Initial Catalog = GranjaAvicola.Data; Data Source=(localdb)\\MSSQLLocalDB; Integrated Security=true");
               }
               catch (System.Exception)
               {
                   OptionsBuilder.UseSqlServer("Initial Catalog = GranjaAvicola.Data; Data Source=LAPTOP-VPO7HRDD\\SQLEXPRESS; Integrated Security=true");
               }                
                
            }
        }
        
        /*
        [Angel/Diseñador de Software] 17/09/2021
        Esta sentencia es para configurar el modelo que se está creando por ahora solo dejar todas las entidades con un HasNokey() para que
        No genere errores el Entity Framework :)
        */

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Galpon>()
                .HasKey(ga => ga.ID_Galpon);
             modelBuilder.Entity<Georeferencias>()
                .HasKey(ge => ge.Id_Georeferencia);
             modelBuilder.Entity<Persona>()
                .HasKey(p => p.Id_Persona);
             modelBuilder.Entity<Registro>()
                .HasKey(re => re.Id_Registro);
             modelBuilder.Entity<Rol>()
                .HasKey(rol => rol.Id_Rol);
             modelBuilder.Entity<Diagnostico>()
                .HasKey(d => d.Id_Diagnostico);
         }
    }
}