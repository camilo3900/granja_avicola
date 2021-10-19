using System;
namespace GranjaAvicola.App.Domain
{
    public class Sugerencia
    {
        public int Id_Sugerencia {get; set;}
        public int ID_Diagnostico {get; set;}
        public string Sugerencias {get; set;}
        public DateTime FechaRegistro {get; set;}
        public int ID_VeterinarioCargo {get; set;}


    }
}