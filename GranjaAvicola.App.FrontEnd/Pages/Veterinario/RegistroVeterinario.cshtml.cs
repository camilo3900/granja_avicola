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
    public class RegistroVeterinarioModel : PageModel
    {        
        private readonly IRepoPersona _repoPersona;
        public IEnumerable<Persona> personas {get; set;}
        public Persona persona {get; set;}
        public Persona Temporal {get; set;}
        public string Message {get; set;} = "";
        
        public string searchID {get;set;}
        public bool searchQueried {get; set;} = false;
        public bool CreateEntry {get;set;} = false;
        public bool updateQueried {get; set;} = false;
        public bool upload {get; set;} = false;

        public RegistroVeterinarioModel(IRepoPersona repoPersona)
        {
            _repoPersona=repoPersona;
        }
        public void OnGet()
        {
            persona = new Persona();
        }
        public void OnPost()
        {

        }
        public void OnPostCreate()
        {
            Temporal = new Persona();
            upload = true;
            Temporal.Nombre = Request.Form["NombreVeterinario"];
            Temporal.Telefono = int.Parse(Request.Form["Telefono"]);
            Temporal.Correo = Request.Form["Correo"];
            //Temporal.Genero = genero.Parse(Request.Form["Genero"]);
            Temporal.ID_Rol = 2;
            Temporal = _repoPersona.AddPersona(Temporal);
            Message = "Veterinario subido con exito";
            Message = $"ID referencia: {Temporal.Id_Persona}";
            CreateEntry = true;
        }
        public void OnPostRead()
        {
            searchID = Request.Form["lolaso"];
            searchQueried = true;
            //galpon = new Galpon();
            persona = _repoPersona.GetPersona(int.Parse(searchID));
           
            if (persona != null && persona.ID_Rol.Equals(2))
            {
                Message = "Veterinario encontrado!"; 
            }
            else
            {
                Message = "GOD FUCKING DAMMIT KRIS WHERE THE FUCK ARE WE!?";
            }
        }
        public void OnPostUpdate_set()
        {
            Temporal = new Persona();
            Temporal.Id_Persona = int.Parse(Request.Form["Update_VeterinarioID"]);
            Temporal.Nombre = Request.Form["Update_NombreVeterinario"];
            Temporal.Telefono = int.Parse(Request.Form["Update_Telefono"]);
            Temporal.Correo = Request.Form["Update_Correo"];
            Temporal.ID_Rol = 2;
            //Temporal.Genero = Request.Form["Update_Genero"];
            _repoPersona.UpdatePersona(Temporal);
            Message = $"Veterinario #{Temporal.Id_Persona} Actualizado";
        }
        public void OnPostUpdate_get()
        {
            var searchID = Request.Form["TempID"];
            persona = _repoPersona.GetPersona(int.Parse(searchID));
            
            if (persona != null && persona.ID_Rol.Equals(2))
            {
                Message = "Se ha encontrado el veterinario";
                updateQueried = true;
            }
            else
            {
                Message = "No se ha encontrado veterinario";
            }
        }
        public void OnPostDelete()
        {
            searchID = Request.Form["TempID"];
            persona = _repoPersona.DeletePersona(int.Parse(searchID));
            if (persona != null && persona.ID_Rol.Equals(2))
            {
                Message = "Veterinario eliminado con exito!";
            }
            else
            {
                Message = "El Veterinario no existe";
            }
        }
    }
}
