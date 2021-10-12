using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace  GranjaAvicola.App.FrontEnd.Pages
{
    public class testModel : PageModel
    {        
        private readonly IRepoGalpon _repoGalpon;
        public IEnumerable<Galpon> galpones {get; set;}
        public Galpon galpon {get; set;}
        public Galpon Temporal {get; set;}
        public string Message { get; set; } = "";
        public string searchID {get;set;}
        public bool searchQueried {get; set;} = false;
        public bool updateQueried {get; set;} = false;
        public bool upload {get; set;} = false;

        public testModel(IRepoGalpon repoGalpon)
        {
            _repoGalpon=repoGalpon;
        }
        public void OnGet()
        {
            galpon = new Galpon();
        }
        public void OnPost()
        {

        }
        public void OnPostCreate()
        {
            Temporal = new Galpon();
            upload = true;
            Temporal.Nombre = Request.Form["NombreGalpon"];
            Temporal.NumeroAnimales = int.Parse(Request.Form["NumeroAnimales"]);
            Temporal.FechaIngreso = DateTime.Parse(Request.Form["FechaIngreso"]);
            Temporal.FechaSalida = DateTime.Parse(Request.Form["FechaSalida"]);
            Temporal = _repoGalpon.AddGalpon(Temporal);
            Message = "Galpon subido con exito";
        }
        public void OnPostRead()
        {
            searchID = Request.Form["lolaso"];
            searchQueried = true;
            //galpon = new Galpon();
            galpon = _repoGalpon.GetGalpon(int.Parse(searchID));
            if (galpon != null)
            {
                Message = "Galpon encontrado!";
            }
            else
            {
                Message = "GOD FUCKING DAMMIT KRIS WHERE THE FUCK ARE WE!?";
            }
        }
        public void OnPostUpdate_set()
        {
            Temporal = new Galpon();
            Temporal.ID_Galpon = int.Parse(Request.Form["Update_GalponID"]);
            Temporal.Nombre = Request.Form["Update_NombreGalpon"];
            Temporal.NumeroAnimales = int.Parse(Request.Form["Update_NumeroAnimales"]);
            Temporal.FechaIngreso = DateTime.Parse(Request.Form["Update_FechaIngreso"]);
            Temporal.FechaSalida = DateTime.Parse(Request.Form["Update_FechaSalida"]);
            _repoGalpon.UpdateGalpon(Temporal);
            Message = $"Galpon #{Temporal.ID_Galpon} Actualizado";
        }
        public void OnPostUpdate_get()
        {
            var searchID = Request.Form["search"];
            galpon = _repoGalpon.GetGalpon(int.Parse(searchID));
            if (galpon != null)
            {
                Message = "Se ha encontrado el galpon";
                updateQueried = true;
            }
            else
            {
                Message = "No se ha encontrado galpon";
            }
        }
        public void OnPostDelete()
        {
            searchID = Request.Form["Delete_Search"];
            galpon = _repoGalpon.DeleteGalpon(int.Parse(searchID));
            if (galpon != null)
            {
                Message = "Galpon eliminado con exito!";
            }
            else
            {
                Message = "El Galpon no existe";
            }
        }
    }
}
