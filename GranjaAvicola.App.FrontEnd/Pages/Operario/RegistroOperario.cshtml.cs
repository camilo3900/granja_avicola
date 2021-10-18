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
    public class RegistroOperarioModel : PageModel
    {        
        private readonly IRepoPersona _repoPersona;
        private readonly IRepoGalpon _repoGalpon;
        public IEnumerable<Persona> personas {get; set;}
        public Persona persona {get; set;}
        public Persona Temporal {get; set;}
        public string Message {get; set;} = "";
        
        public string searchID {get;set;}
        public bool searchQueried {get; set;} = false;
        public bool CreateEntry {get;set;} = false;
        public bool updateQueried {get; set;} = false;
        public bool upload {get; set;} = false;
         

        public RegistroOperarioModel(IRepoPersona repoPersona, IRepoGalpon repoGalpon)
        {
            _repoPersona=repoPersona;
            _repoGalpon=repoGalpon;
        }
        public void OnGet()
        {
            persona = new Persona();
            personas = _repoPersona.GetAllPersona();
            
        }
        public void OnPost()
        {

        }
        public void OnPostCreate()
        {
            Temporal = new Persona();
            upload = true;
            Temporal.Nombre = Request.Form["NombreOperario"];
            Temporal.Telefono = int.Parse(Request.Form["Telefono"]);
            Temporal.Correo = Request.Form["Correo"];
            //Temporal.Genero = genero.Parse(Request.Form["Genero"]);
            Temporal.ID_Rol = 1;
            Temporal = _repoPersona.AddPersona(Temporal);
            Message = "Operario subido con exito";
            Message = $"ID referencia: {Temporal.Id_Persona}";
            CreateEntry = true;
        }
        public void OnPostRead()
        {
            personas = _repoPersona.GetAllPersona();
            searchID = Request.Form["lolaso"];
            searchQueried = true;
            //galpon = new Galpon();
            
            persona = _repoPersona.GetPersona(int.Parse(searchID));
            
            
           
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                Message = "Operario encontrado!"; 
            }
            else
            {
                Message = "GOD FUCKING DAMMIT KRIS WHERE THE FUCK ARE WE!?";
            }
        }
        public void OnPostUpdate_set()
        {
            Temporal = new Persona();
            Temporal.Id_Persona = int.Parse(Request.Form["Update_OperarioID"]);
            Temporal.Nombre = Request.Form["Update_NombreOperario"];
            Temporal.Telefono = int.Parse(Request.Form["Update_Telefono"]);
            Temporal.Correo = Request.Form["Update_Correo"];
            Temporal.ID_Rol = 1;
            //Temporal.Genero = Request.Form["Update_Genero"];
            _repoPersona.UpdatePersona(Temporal);
            Message = $"Operario #{Temporal.Id_Persona} Actualizado";
        }
        public void OnPostUpdate_get()
        {
            var searchID = Request.Form["TempID"];
            persona = _repoPersona.GetPersona(int.Parse(searchID));
            
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                Message = "Se ha encontrado el operario";
                updateQueried = true;
            }
            else
            {
                Message = "No se ha encontrado operario";
            }
        }
        public void OnPostDelete()
        {
            searchID = Request.Form["TempID"];
            persona = _repoPersona.DeletePersona(int.Parse(searchID));
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                Message = "Operarioo eliminado con exito!";
            }
            else
            {
                Message = "El Operario no existe";
            }
        }
    }
}
