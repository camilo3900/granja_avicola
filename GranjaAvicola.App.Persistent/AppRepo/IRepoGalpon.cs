using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Domain
{
    public interface IRepoGalpon
    {
        IEnumerable<Galpon> GetAllGalpon();
        Galpon AddGalpon(Galpon galpon);
        Galpon UpdateGalpon(Galpon galpon);
        void DeleteGalpon(int idGalpon);
        Galpon GetGalpon(int idGalpon);
    }
}