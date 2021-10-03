
using System.Collections.Generic;
using System.Linq;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Domain
{
    public class RepoDiagnostico : IRepoDiagnostico
    {
        /// <summary>
        /// Referencia al contexto de Paciente
        /// </summary>
        private readonly WebAppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepoDiagnostico(WebAppContext appContext)
        {
            _appContext = appContext;
        }
        Diagnostico IRepoDiagnostico.AddDiagnostico(Diagnostico Diagnostico)
        {
            var DiagnosticoAdd = _appContext.Diagnostico.Add(Diagnostico);
            _appContext.SaveChanges();
            return DiagnosticoAdd.Entity;
        }

        void IRepoDiagnostico.DeleteDiagnostico(int idDiagnostico)
        {
            var DiagnosticoEncontrado = _appContext.Diagnostico.FirstOrDefault(g => g.Id_Diagnostico == idDiagnostico);
            if (DiagnosticoEncontrado == null)
                return;
            _appContext.Diagnostico.Remove(DiagnosticoEncontrado);
            _appContext.SaveChanges();

        }

        IEnumerable<Diagnostico> IRepoDiagnostico.GetAllDiagnostico()
        {
            return _appContext.Diagnostico;
        }

        Diagnostico IRepoDiagnostico.GetDiagnostico(int idDiagnostico)
        {
            return  _appContext.Diagnostico.FirstOrDefault(g => g.Id_Diagnostico== idDiagnostico);
            
        }

        Diagnostico IRepoDiagnostico.UpdateDiagnostico(Diagnostico Diagnostico)
        {
            var DiagnosticoEncontrado = _appContext.Diagnostico.FirstOrDefault(g => g.Id_Diagnostico == Diagnostico.Id_Diagnostico);
            if(DiagnosticoEncontrado!=null)
            {
                // DiagnosticoEncontrado.Georeferencia=Diagnostico.Georeferencia;
                DiagnosticoEncontrado.DiagnosticoVet=Diagnostico.DiagnosticoVet;
                DiagnosticoEncontrado.Sugerencia = Diagnostico.Sugerencia;

                _appContext.SaveChanges();
            }
            return DiagnosticoEncontrado;
            
        }
    }
}