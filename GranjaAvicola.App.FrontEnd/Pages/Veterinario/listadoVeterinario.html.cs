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
    public class listadoVeterinarioModel : PageModel
    {
        private readonly IRepoPersona _repoPersona;
        public IEnumerable<Persona> persona {get; set;}

        public listadoVeterinarioModel(IRepoPersona repoPersona)
        {
            _repoPersona=repoPersona;
        }
        public void OnGet()
        {
            persona=_repoPersona.GetAllPersona();
        }
    }
}
