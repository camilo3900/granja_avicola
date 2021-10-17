using System.ComponentModel.DataAnnotations;
namespace GranjaAvicola.App.Domain
{
    // Refactorización 
    /// <summary> <c>Persona</c>
        /// Referencia al contexto de Paciente
        /// </summary>
    public class Persona
    {
        public int Id_Persona{get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public long Telefono {get;set;}
        public string Correo {get;set;}
        public string Genero {get; set;}
        public int ID_GalponAsignado {get; set;}
        public int ID_Rol{get;set;}
    }
    
}