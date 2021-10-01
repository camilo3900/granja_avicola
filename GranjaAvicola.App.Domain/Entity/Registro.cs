using System;
namespace GranjaAvicola.App.Domain
{
    public class Registro 
    {
        public int Id {get; set;}
        public int ID_Galpon {get; set;}
        public DateTime FechaRegistro {get; set;}
        public double Temperatura {get; set;}
        public double Agua {get; set;}
        public double Alimento {get; set;}
        public int PromedioHuevos {get; set;}
        public int GallinasEnfermas {get; set;}
        public int ID_Trabajador {get; set;}
    }
}