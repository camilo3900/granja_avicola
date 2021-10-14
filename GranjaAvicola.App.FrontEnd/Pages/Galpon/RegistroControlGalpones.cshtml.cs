using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GranjaAvicola.App.Domain;
using GranjaAvicola.App.Persistent;

namespace GranjaAvicola.App.FrontEnd.Pages
{
    public class RegistroControlGalponesModel : PageModel
    {
        private readonly IRepoGalpon _repoGalpon;
        private readonly IRepoGeoreferencias _repoGeoreferencia;
        public Galpon galpon {get; set;}
        public Galpon TemporalGalpon {get; set;}
        public Georeferencias georeferencia {get; set;}
        public Georeferencias Temporalgeoref {get; set;}
        public string[] Message = new string[] {"", "", "", ""};
        public string searchID {get; set;}
        public bool CreateEntry {get;set;} = false;
        public bool searchQueried {get; set;} = false;
        public bool UpdateState {get; set;} = false;

        public RegistroControlGalponesModel(IRepoGalpon repoGalpon, IRepoGeoreferencias repoGeoreferencias)
        {
            _repoGalpon=repoGalpon;
            _repoGeoreferencia=repoGeoreferencias;
        }
        public void OnGet()
        {
            
            galpon = new Galpon();
            georeferencia = new Georeferencias();
        }
        public void OnPost()
        {
            
        }
        public void OnPostCreate()
        {
            TemporalGalpon = new Galpon();
            Temporalgeoref = new Georeferencias();
            
            TemporalGalpon.Nombre = Request.Form["NombreGalpon"];
            TemporalGalpon.NumeroAnimales = int.Parse(Request.Form["NumeroAnimales"]);
            TemporalGalpon.FechaIngreso = DateTime.Parse(Request.Form["FechaIngreso"]);
            TemporalGalpon.FechaSalida = DateTime.Parse(Request.Form["FechaSalida"]);
            
            Temporalgeoref.altitud = double.Parse(Request.Form["Altitud"]); 
            Temporalgeoref.latitud = double.Parse(Request.Form["Latitud"]); 
            Temporalgeoref = _repoGeoreferencia.AddGeoreferencia(Temporalgeoref);

            TemporalGalpon.Georeferencia = Temporalgeoref.Id_Georeferencia;

            TemporalGalpon = _repoGalpon.AddGalpon(TemporalGalpon);
            Message[0] = "Galpon subido con exito";
            Message[1] = $"ID referencia: {TemporalGalpon.ID_Galpon}";
            CreateEntry = true;
        }
        public void OnPostRead()
        {
            searchID = Request.Form["SearchID"];
            //galpon = new Galpon();
            galpon = _repoGalpon.GetGalpon(int.Parse(searchID));
            searchQueried = true;
            if (galpon == null)
            {
                Message[2] = "No encontrado";
            }
            else
            {
                georeferencia = _repoGeoreferencia.GetGeoreferencia(galpon.Georeferencia);
            }

        }
        public void OnPostUpdate_get()
        {
            searchID = Request.Form["TempID"];
            galpon = _repoGalpon.GetGalpon(int.Parse(searchID));
            georeferencia = _repoGeoreferencia.GetGeoreferencia(galpon.Georeferencia);
            UpdateState = true;
        }
        
        public void OnPostUpdate_set()
        {
            TemporalGalpon = new Galpon();
            Temporalgeoref = new Georeferencias();

            TemporalGalpon.ID_Galpon = int.Parse(Request.Form["Update_GalponID"]);
            TemporalGalpon.Nombre = Request.Form["Update_NombreGalpon"];
            TemporalGalpon.NumeroAnimales = int.Parse(Request.Form["Update_NumeroAnimales"]);
            TemporalGalpon.FechaIngreso = DateTime.Parse(Request.Form["Update_FechaIngreso"]);
            TemporalGalpon.FechaSalida = DateTime.Parse(Request.Form["Update_FechaSalida"]);
            TemporalGalpon.Georeferencia = int.Parse(Request.Form["Update_IDgeoreferencias"]);

            Temporalgeoref.Id_Georeferencia = TemporalGalpon.Georeferencia;
            Temporalgeoref.altitud = double.Parse(Request.Form["Update_Altitud"]); 
            Temporalgeoref.latitud = double.Parse(Request.Form["Update_Latitud"]); 
            
            _repoGeoreferencia.UpdateGeoreferencia(Temporalgeoref);
            _repoGalpon.UpdateGalpon(TemporalGalpon);
        }
        public void OnPostDelete()
        {
            searchID = Request.Form["TempID"];
            galpon = _repoGalpon.DeleteGalpon(int.Parse(searchID));
        }
    }
}
