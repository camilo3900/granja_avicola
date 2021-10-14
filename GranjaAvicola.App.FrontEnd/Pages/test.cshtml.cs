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
        private readonly IRepoGeoreferencias _repoGeoreferencias;
        public IEnumerable<Galpon> galpones {get; set;}
        public Galpon galpon {get; set;}
        public Galpon TemporalGalpon {get; set;}
        public Georeferencias georeferencia {get; set;}
        public Georeferencias Temporalgeoref {get; set;}
        public string Message { get; set; } = "";
        public string searchID {get;set;}
        public bool searchQueried {get; set;} = false;
        public bool updateQueried {get; set;} = false;
        public bool upload {get; set;} = false;

        public testModel(IRepoGalpon repoGalpon, IRepoGeoreferencias repoGeoreferencias)
        {
            _repoGalpon=repoGalpon;
            _repoGeoreferencias=repoGeoreferencias;
        }
        public void OnGet()
        {
            georeferencia = new Georeferencias();
            galpon = new Galpon();
        }
        public void OnPost()
        {

        }
        public void OnPostCreate()
        {
            TemporalGalpon = new Galpon();
            Temporalgeoref = new Georeferencias();
            upload = true;
            
            TemporalGalpon.Nombre = Request.Form["NombreGalpon"];
            TemporalGalpon.NumeroAnimales = int.Parse(Request.Form["NumeroAnimales"]);
            TemporalGalpon.FechaIngreso = DateTime.Parse(Request.Form["FechaIngreso"]);
            TemporalGalpon.FechaSalida = DateTime.Parse(Request.Form["FechaSalida"]);
            
            Temporalgeoref.altitud = double.Parse(Request.Form["Altitud"]); 
            Temporalgeoref.latitud = double.Parse(Request.Form["Latitud"]); 
            Temporalgeoref = _repoGeoreferencias.AddGeoreferencia(Temporalgeoref);

            TemporalGalpon.Georeferencia = Temporalgeoref.Id_Georeferencia;

            TemporalGalpon = _repoGalpon.AddGalpon(TemporalGalpon);
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
            TemporalGalpon = new Galpon();
            TemporalGalpon.ID_Galpon = int.Parse(Request.Form["Update_GalponID"]);
            TemporalGalpon.Nombre = Request.Form["Update_NombreGalpon"];
            TemporalGalpon.NumeroAnimales = int.Parse(Request.Form["Update_NumeroAnimales"]);
            TemporalGalpon.FechaIngreso = DateTime.Parse(Request.Form["Update_FechaIngreso"]);
            TemporalGalpon.FechaSalida = DateTime.Parse(Request.Form["Update_FechaSalida"]);
            _repoGalpon.UpdateGalpon(TemporalGalpon);
            Message = $"Galpon #{TemporalGalpon.ID_Galpon} Actualizado";
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
