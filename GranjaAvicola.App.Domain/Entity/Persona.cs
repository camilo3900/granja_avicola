using System.ComponentModel.DataAnnotations;
namespace GranjaAvicola.App.Domain
{
    public class Persona
    {
        public int Id_Persona{get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public long Telefono {get;set;}
        public string Correo {get;set;}
        public string Genero {get; set;}
        public int ID_Rol{get;set;}
        public int ID_GalponAsignado{get;set;}
    }
    
}