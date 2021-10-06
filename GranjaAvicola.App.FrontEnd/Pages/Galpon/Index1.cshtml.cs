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
    public class Index1Model : PageModel
    {
        private readonly IRepoGalpon _repoGalpon;
        public IEnumerable<Galpon> galpones {get; set;}

        public Index1Model(IRepoGalpon repoGalpon)
        {
            _repoGalpon=repoGalpon;
        }
        public void OnGet()
        {
            galpones=_repoGalpon.GetAllGalpon();
        }
    }
}
