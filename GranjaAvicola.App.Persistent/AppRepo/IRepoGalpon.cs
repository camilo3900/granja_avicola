using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public interface IRepoGalpon
    {
        IEnumerable<Galpon> GetAllGalpon();
        Galpon AddGalpon(Galpon galpon);
        Galpon UpdateGalpon(Galpon galpon);
        Galpon DeleteGalpon(int idGalpon);
        Galpon GetGalpon(int idGalpon);
    }
}