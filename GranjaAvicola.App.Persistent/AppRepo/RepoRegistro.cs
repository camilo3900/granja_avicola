
using System.Collections.Generic;
using System.Linq;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Persistent
{
    public class RepoRegistro : IRepoRegistro
    {
        /// <summary>
        /// Referencia al contexto de Paciente
        /// </summary>
        private readonly WebAppContext _appContext = new WebAppContext();
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepoRegistro(){
            
        }
        public RepoRegistro(WebAppContext appContext)
        {
            _appContext = appContext;
        }
        Registro IRepoRegistro.AddRegistro(Registro Registro)
        {
            var RegistroAdd = _appContext.Registro.Add(Registro);
            _appContext.SaveChanges();
            return RegistroAdd.Entity;
        }

        void IRepoRegistro.DeleteRegistro(int idRegistro)
        {
            var RegistroEncontrado = _appContext.Registro.FirstOrDefault(g => g.Id_Registro == idRegistro);
            if (RegistroEncontrado == null)
                return;
            _appContext.Registro.Remove(RegistroEncontrado);
            _appContext.SaveChanges();

        }

        IEnumerable<Registro> IRepoRegistro.GetAllRegistro()
        {
            return _appContext.Registro;
        }

        Registro IRepoRegistro.GetRegistro(int idRegistro)
        {
            return  _appContext.Registro.FirstOrDefault(g => g.Id_Registro== idRegistro);
            
        }

        Registro IRepoRegistro.UpdateRegistro(Registro Registro)
        {
            var RegistroEncontrado = _appContext.Registro.FirstOrDefault(g => g.Id_Registro == Registro.Id_Registro);
            if(RegistroEncontrado!=null)
            {
                // RegistroEncontrado.Georeferencia=Registro.Georeferencia;
                RegistroEncontrado.FechaRegistro=Registro.FechaRegistro;
                RegistroEncontrado.Temperatura=Registro.Temperatura;
                RegistroEncontrado.Agua = Registro.Agua;
                RegistroEncontrado.Alimento=Registro.Alimento;
                RegistroEncontrado.PromedioHuevos=Registro.PromedioHuevos;
                RegistroEncontrado.GallinasEnfermas=Registro.GallinasEnfermas;
                RegistroEncontrado.ID_Galpon=Registro.ID_Galpon;
                RegistroEncontrado.ID_Trabajador=Registro.ID_Trabajador;

                

                _appContext.SaveChanges();
            }
            return RegistroEncontrado;
            
        }
    }
}