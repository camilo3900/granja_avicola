using Microsoft.EntityFrameworkCore;

namespace GranjaAvicola.App.Persistent
{
    public class AppContext : DBContext
    {
        public Dbset<Persona> Personas {get;set;}
    }
}