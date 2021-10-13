using System.Collections.Generic;
using GranjaAvicola.App.Domain;

namespace GranjaAvicola.App.Persistent
{
    public interface IRepoGeoreferencias
    {
        Georeferencias AddGeoreferencia(Georeferencias georeferencia);
        Georeferencias UpdateGeoreferencia(Georeferencias georeferencia);
        Georeferencias DeleteGeoreferencia(int Idgeoreferencia);
        Georeferencias GetGeoreferencia(int Idgeoreferencia);
    }
}