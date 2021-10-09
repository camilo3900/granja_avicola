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
        public string Message { get; set; } = "Initial Request";
        public string searchID { get; set;}
        public bool searchQueried {get; set;} = false;
        public bool uploadQueue {get; set;} = false;

        public testModel(IRepoGalpon repoGalpon)
        {
            _repoGalpon=repoGalpon;
        }
        public void OnGet()
        {
            
        }

        public void OnPost()
        {

        }


        public void OnPostRegister()
        {
            Temporal = new Galpon();
            uploadQueue = true;
            Temporal.Nombre = Request.Form["NombreGalpon"];
            Temporal.NumeroAnimales = int.Parse(Request.Form["NumeroAnimales"]);
            Temporal.FechaIngreso = DateTime.Parse(Request.Form["FechaIngreso"]);
            Temporal.FechaSalida = DateTime.Parse(Request.Form["FechaSalida"]);
            _repoGalpon.AddGalpon(Temporal);
            
        }

        public void OnPostView()
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
    }
}
