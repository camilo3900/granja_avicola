using System;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Console
{
    class Program
    {
        private static IRepoGalpon _repoGalpon = new RepoGalpon(new Persistent.WebAppContext());
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            AddGalpon();
        }

        private static void AddGalpon()
        {
            var galpon = new Galpon
            {
                
                Nombre = "Mañanitas",
                NumeroAnimales = 203,
                FechaIngreso = new DateTime (2020,02,25),
                FechaSalida = new DateTime(2021, 11, 02)
            };
            _repoGalpon.AddGalpon(galpon);
        }
    }
}
