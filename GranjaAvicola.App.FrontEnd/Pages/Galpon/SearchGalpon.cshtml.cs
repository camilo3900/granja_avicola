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
    public class SearchGalponModel : PageModel
    {
        private readonly IRepoGalpon _repoGalpon;
        public IEnumerable<Galpon> galpones {get; set;}
        public Galpon galpon {get; set;}

        public SearchGalponModel(IRepoGalpon repoGalpon)
        {
            _repoGalpon=repoGalpon;
        }
        public IActionResult OnGet(int id)
        {
            galpon = new Galpon();
            galpones=_repoGalpon.GetAllGalpon();
            galpon = _repoGalpon.GetGalpon(id);
            if (galpon == null)
            {
                return NotFound();
            } 
            else
            {
                return Page();
            }
           
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
