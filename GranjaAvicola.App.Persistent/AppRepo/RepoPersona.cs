
using System.Collections.Generic;
using System.Linq;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Persistent
{
    public class RepoPersona : IRepoPersona
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
        public RepoPersona(){

        }
        public RepoPersona(WebAppContext appContext)
        {
            _appContext = appContext;
        }
        Persona IRepoPersona.AddPersona(Persona Persona)
        {
            var PersonaAdd = _appContext.Persona.Add(Persona);
            _appContext.SaveChanges();
            return PersonaAdd.Entity;
        }

        Persona IRepoPersona.DeletePersona(int idPersona)
        {
            var PersonaEncontrado = _appContext.Persona.FirstOrDefault(g => g.Id_Persona == idPersona);
            if (PersonaEncontrado == null)
                return null;
            else {
            _appContext.Persona.Remove(PersonaEncontrado);
            _appContext.SaveChanges();
            return PersonaEncontrado;
            }

        }

        IEnumerable<Persona> IRepoPersona.GetAllPersona()
        {
            return _appContext.Persona;
        }

        Persona IRepoPersona.GetPersona(int idPersona)
        {
            return  _appContext.Persona.FirstOrDefault(g => g.Id_Persona== idPersona);
            
        }

        Persona IRepoPersona.UpdatePersona(Persona Persona)
        {
            var PersonaEncontrado = _appContext.Persona.FirstOrDefault(g => g.Id_Persona == Persona.Id_Persona);
            if(PersonaEncontrado!=null)
            {
                // PersonaEncontrado.Georeferencia=Persona.Georeferencia;
                PersonaEncontrado.Nombre=Persona.Nombre;
                PersonaEncontrado.Apellido = Persona.Apellido;
                PersonaEncontrado.Telefono=Persona.Telefono;
                PersonaEncontrado.Correo=Persona.Correo;
                PersonaEncontrado.Genero=Persona.Genero;
                PersonaEncontrado.ID_Rol=Persona.ID_Rol;

                

                _appContext.SaveChanges();
            }
            return PersonaEncontrado;
            
        }
    }
}