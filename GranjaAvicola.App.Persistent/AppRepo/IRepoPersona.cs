using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public interface IRepoPersona
    {
        IEnumerable<Persona> GetAllPersona();
    
        Persona AddPersona(Persona Persona);
        Persona UpdatePersona(Persona Persona);
        Persona DeletePersona(int idPersona);
        Persona GetPersona(int idPersona);
    }
}