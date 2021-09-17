namespace GranjaAvicola.App.Domain
{
    public class Historia 
    {
        public int ID_Registro {get; set;}
        public int ID_Galpon {get; set;}
        public string FechaRegistro {get; set;}
        public double Temperatura {get; set;}
        public double Agua {get; set;}
        public double Alimento {get; set;}
        public int PromedioHuevos {get; set;}
        public int GallinasEnfermas {get; set;}
        public int ID_Trabajador {get; set;}
    }
}