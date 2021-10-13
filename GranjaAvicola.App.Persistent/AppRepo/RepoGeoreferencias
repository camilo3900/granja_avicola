using System.Collections.Generic;
using System.Linq;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Persistent
{
    public class RepoGeoreferencias : IRepoGeoreferencias
    {
        private readonly WebAppContext _appContext = new WebAppContext();

        public RepoGeoreferencias()
        {

        }
        Georeferencias IRepoGeoreferencias.AddGeoreferencia(Georeferencias georeferencia)
        {
            var georeferenciaAdd = _appContext.Georeferencias.Add(georeferencia);
            _appContext.SaveChanges();
            return georeferenciaAdd.Entity;
        }
        Georeferencias IRepoGeoreferencias.DeleteGeoreferencia(int idGeoreferencia)
        {
            var georeferenciaFound = _appContext.Georeferencias.FirstOrDefault(geo => geo.Id_Georeferencia == idGeoreferencia);
            if (georeferenciaFound == null)
            {
                return null;
            }
            else
            {
                _appContext.Georeferencias.Remove(georeferenciaFound);
                _appContext.SaveChanges();
                return georeferenciaFound;
            }
        }
        Georeferencias IRepoGeoreferencias.GetGeoreferencia(int idGeoreferencia)
        {
            try
            {
                return _appContext.Georeferencias.FirstOrDefault(geo => geo.Id_Georeferencia == idGeoreferencia);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }
        Georeferencias IRepoGeoreferencias.UpdateGeoreferencia(Georeferencias georeferencia)
        {
            var georeferenciaFound = _appContext.Georeferencias.FirstOrDefault(geo => geo.Id_Georeferencia == georeferencia.Id_Georeferencia);
            if(georeferenciaFound != null)
            {
                georeferenciaFound.latitud = georeferencia.latitud;
                georeferenciaFound.altitud = georeferencia.altitud;
                _appContext.SaveChanges();
            }
            return georeferenciaFound;
        }
    }
}