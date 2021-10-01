namespace GranjaAvicola.App.Domain
{
    public class Persona
    {
        public int Id{get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public int Telefono {get;set;}
        public string Correo {get;set;}
        public genero Genero {get; set;}
        public int ID_Rol{get;set;}
    }
    
}