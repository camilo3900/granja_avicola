
using System.Collections.Generic;
using System.Linq;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Persistent
{
    public class RepoGalpon : IRepoGalpon
    {
        private readonly WebAppContext _appContext = new WebAppContext();

        public RepoGalpon(){

        }
        public RepoGalpon(WebAppContext appContext)
        {
            _appContext = appContext;
        }
        Galpon IRepoGalpon.AddGalpon(Galpon galpon)
        {
            var galponAdd = _appContext.Galpon.Add(galpon);
            _appContext.SaveChanges();
            return galponAdd.Entity;
        }
        Galpon IRepoGalpon.DeleteGalpon(int idGalpon)
        {
            var galponEncontrado = _appContext.Galpon.FirstOrDefault(g => g.ID_Galpon == idGalpon);
            if (galponEncontrado == null)
            {
                return null;
            }
            else 
            {
                _appContext.Galpon.Remove(galponEncontrado);
                _appContext.SaveChanges();
                return galponEncontrado;
            }
        }

        IEnumerable<Galpon> IRepoGalpon.GetAllGalpon()
        {
            return _appContext.Galpon;
        }

        Galpon IRepoGalpon.GetGalpon(int idGalpon)
        {
            try
            {
                return  _appContext.Galpon.FirstOrDefault(g => g.ID_Galpon == idGalpon); 
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
            
        }

        Galpon IRepoGalpon.UpdateGalpon(Galpon galpon)
        {
            var galponEncontrado = _appContext.Galpon.FirstOrDefault(g => g.ID_Galpon == galpon.ID_Galpon);
            if(galponEncontrado!=null)
            {
                // galponEncontrado.Georeferencia=galpon.Georeferencia;
                galponEncontrado.Nombre=galpon.Nombre;
                galponEncontrado.NumeroAnimales=galpon.NumeroAnimales;
                galponEncontrado.FechaIngreso=galpon.FechaIngreso;
                galponEncontrado.FechaSalida=galpon.FechaSalida;
                

                _appContext.SaveChanges();
            }
            return galponEncontrado;
            
        }
    }
}