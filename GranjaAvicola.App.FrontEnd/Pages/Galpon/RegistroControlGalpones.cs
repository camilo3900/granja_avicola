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
        public Galpon galpon {get; set;}
        public string Message {get;set;} = "Initial Request";
        public string searchID {get; set;}
        public bool searchQueried {get; set;} = false;

        public RegistroControlGalponesModel(IRepoGalpon repoGalpon)
        {
            _repoGalpon=repoGalpon;
        }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            Message = "Form Posted";
        }

        public void OnPostView()
        {
            
            searchID = Request.Form["SearchID"];
            searchQueried = true;
            //galpon = new Galpon();
            galpon = _repoGalpon.GetGalpon(int.Parse(searchID));
            if (galpon != null)
            {
                Message = "Galpon encontrado!";
                
            }
            else
            {
                Message = "Galpon no encontrado.";
            }
        }
    }
}
