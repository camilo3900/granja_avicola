using Microsoft.EntityFrameworkCore;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Persona {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if(!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GranjaAvicola.data");
            }
        }
    }
}