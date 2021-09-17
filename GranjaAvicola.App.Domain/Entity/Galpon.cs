namespace GranjaAvicola.App.Domain
{
    public class Galpon
    {
        public int ID_Galpon {get; set;}
        public int Georeferencia {get; set;}
        public int ID_OperarioCargo {get; set;}
        public int ID_VeterinarioCargo {get; set;}
        public string Nombre {get; set;}
        public int NumeroAnimales {get; set;}
        public string FechaIngreso {get; set;}
        public string FechaSalida {get; set;}
    }
}