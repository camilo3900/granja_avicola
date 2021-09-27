
using System.Collections.Generic;
using System.Linq;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Domain
{
    public class RepoGalpon : IRepoGalpon
    {
        /// <summary>
        /// Referencia al contexto de Paciente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepoGalpon(AppContext appContext)
        {
            _appContext = appContext;
        }
        public Galpon AddGalpon(Galpon galpon)
        {
            var galponAdd = _appContext.Galpon.Add(galpon);
            _appContext.SaveChanges();
            return galponAdd.Entity;
        }

        public void DeleteGalpon(int idGalpon)
        {
            var galponEncontrado = _appContext.Galpon.FirstOrDefault(g => g.ID_Galpon == idGalpon);
            if (galponEncontrado == null)
                return;
            _appContext.Galpon.Remove(galponEncontrado);
            _appContext.SaveChanges();

        }

        public IEnumerable<Galpon> GetAllGalpon()
        {
            return _appContext.Galpon;
        }

        public Galpon GetGalpon(int idGalpon)
        {
            return  _appContext.Galpon.FirstOrDefault(g => g.ID_Galpon == idGalpon);
            
        }

        public Galpon UpdateGalpon(Galpon galpon)
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