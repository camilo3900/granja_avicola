using System;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Console
{
    class Program
    {
        private static IRepoGalpon _repoGalpon = new RepoGalpon(new Persistent.AppContext());
        static void Main(string[] args)
        {
            
            AddGalpon();
        }

        private static void AddGalpon()
        {
            var galpon = new Galpon
            {
                // Georeferencia = 3490762,
                Nombre="Mañanitas",
                NumeroAnimales = 2500,
                FechaIngreso = new DateTime(2020, 01, 27),
                FechaSalida = new DateTime(2021, 02, 02)
                
            };
            _repoGalpon.AddGalpon(galpon);
        }

    }
}

