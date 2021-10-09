using System;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.Console
{
    class Program
    {
        private static IRepoGalpon _repoGalpon = new RepoGalpon(new Persistent.WebAppContext());
        private static IRepoPersona _repoPersona = new RepoPersona(new Persistent.WebAppContext());
        private static IRepoDiagnostico _repoDiagnostico = new RepoDiagnostico(new Persistent.WebAppContext());
        private static IRepoRegistro _repoRegistro = new RepoRegistro(new Persistent.WebAppContext());

        


        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            //AddGalpon();
            //AddPersona();
            //AddDiagnostico();
            //AddRegistro();
            //getGalpon(1);
            //getGalpon(100);
            for (int i = 1; i < 50; i++)
            {
                deleteGalpon(i);
            }
        }

        private static void AddGalpon()
        {
            var galpon = new Galpon
            {
                Nombre = "Lolaso",
                NumeroAnimales = 203,
                FechaIngreso = new DateTime (2020,02,25),
                FechaSalida = new DateTime(2021, 11, 02)
            };
            _repoGalpon.AddGalpon(galpon);
        }
        private static void AddPersona()
        {
            var persona = new Persona
            {
                Nombre = "Doc",
                Apellido = "Veterinario",
                Telefono = 3752 ,
                Correo = "Doc@mintic.com",

            };
            _repoPersona.AddPersona(persona);
        }
        private static void AddDiagnostico()
        {
            var diagnostico = new Diagnostico
            {
                DiagnosticoVet = "Diagnotico 1.0",
                Sugerencia = "New Sugerencia"


            };
            _repoDiagnostico.AddDiagnostico(diagnostico);
        }
        private static void AddRegistro()
        {
            var registro = new Registro
            {
                FechaRegistro = new DateTime(2022,10,02),
                Temperatura = 35,
                Agua = 500,
                Alimento = 0.1,
                PromedioHuevos = 25,
                GallinasEnfermas = 3
            };
            _repoRegistro.AddRegistro(registro);
        }
        private static void getGalpon(int idGalpon)
        {
            var galpon = _repoGalpon.GetGalpon(idGalpon);
            if (galpon != null)
            {
                System.Console.WriteLine("Galpon encontrado\n"+galpon.Nombre + " " + galpon.ID_Galpon);
            }
        }

        private static void deleteGalpon(int idGalpon)
        {
            _repoGalpon.DeleteGalpon(idGalpon);
            System.Console.WriteLine("Galpon eliminado" + idGalpon);
        }
    }
}
