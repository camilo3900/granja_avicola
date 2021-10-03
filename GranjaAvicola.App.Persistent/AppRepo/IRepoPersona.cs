using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Domain
{
    public interface IRepoPersona
    {
        IEnumerable<Persona> GetAllPersona();
        Persona AddPersona(Persona Persona);
        Persona UpdatePersona(Persona Persona);
        void DeletePersona(int idPersona);
        Persona GetPersona(int idPersona);
    }
}