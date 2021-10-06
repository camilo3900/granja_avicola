using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public interface IRepoRegistro
    {
        IEnumerable<Registro> GetAllRegistro();
        Registro AddRegistro(Registro Registro);
        Registro UpdateRegistro(Registro Registro);
        void DeleteRegistro(int idRegistro);
        Registro GetRegistro(int idRegistro);
    }
}