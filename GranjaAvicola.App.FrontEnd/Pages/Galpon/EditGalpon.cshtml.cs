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
    public class EditGalponModel : PageModel
    {
        private readonly IRepoGalpon _repoGalpon;
        public IEnumerable<Galpon> galpones {get; set;}
        public Galpon galpon {get; set;}

        public EditGalponModel(IRepoGalpon repoGalpon)
        {
            _repoGalpon=repoGalpon;
        }
        public void OnGet()
        {
            galpon = new Galpon();
            galpones=_repoGalpon.GetAllGalpon();
           
        }
        public IActionResult OnPost(Galpon galpon)
        {
            if (ModelState.IsValid)
            {
                _repoGalpon.AddGalpon(galpon);
                return RedirectToPage("RegistroGalpon");
            } else
            {
                return Page();
            }
        }
    }
}
