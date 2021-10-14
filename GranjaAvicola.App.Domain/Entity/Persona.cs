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
        //**
        [Required(ErrorMessage ="Este es un compo obligatorio")]
        [StringLength(50, ErrorMessage ="Longitud Maxima 50 Caracteres")]
        public string Nombre {get;set;}
        [Required(ErrorMessage ="Este es un compo obligatorio")]
        [StringLength(50, ErrorMessage ="Longitud Maxima 50 Caracteres")]
        public string Apellido {get;set;}
        public int Telefono {get;set;}
        //[Required(ErrorMessage ="Este es un compo obligatorio")]
        //[StringLength(20, ErrorMessage ="Longitud Maxima 20 Caracteres")]
        public string Correo {get;set;}
        [Required(ErrorMessage ="Este es un compo obligatorio")]
        [StringLength(50, ErrorMessage ="Longitud Maxima 50 Caracteres")]
        public genero Genero {get; set;}
        public int ID_Rol{get;set;}
    }
    
}