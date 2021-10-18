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
    public class RegistroVariablesModel : PageModel
    {
        private readonly IRepoPersona _repoPersona;
        private readonly IRepoGalpon _repoGalpon;
        private readonly IRepoRegistro _repoRegistro;
        public IEnumerable<Persona> personas {get; set;}
        public IEnumerable<Registro> registros {get; set;}

        public Galpon galpon {get; set;}
        public Persona persona {get; set;}
        public Registro registro {get;set;}
        public Registro Temporal {get; set;}
        public string Message {get; set;} = "";
        
        public string searchID {get;set;} ="";
        public int ID_Galpon {get;set;} = 0;
        public int ID_Trabajador {get;set;} = 0;
        public int add {get;set;} = 0;
        public int search {get;set;} = 0;
        public bool searchQueried {get; set;} = false;
         public bool searchQueried2 {get; set;} = false;
        public bool CreateEntry {get;set;} = false;
        public bool updateQueried {get; set;} = false;
        public bool upload {get; set;} = false;
         

        public RegistroVariablesModel(IRepoPersona repoPersona, IRepoGalpon repoGalpon, IRepoRegistro repoRegistro)
        {
            _repoPersona=repoPersona;
            _repoGalpon=repoGalpon;
            _repoRegistro=repoRegistro;
        }
        public void OnGet()
        {
            persona = new Persona();
            registro = new Registro();
            personas = _repoPersona.GetAllPersona();
            registros = _repoRegistro.GetAllRegistro();

            
        }
        public void OnPost()
        {

        }
        public void OnPostCreate()
        {
            Temporal = new Registro();
            upload = true;
            searchID = Request.Form["lolaso"];
            

            Temporal.ID_Galpon = int.Parse(Request.Form["ID_Galpon"]);
            Temporal.ID_Trabajador = int.Parse(Request.Form["ID_Trabajador"]);
            Temporal.Temperatura = double.Parse(Request.Form["Temperatura"]);
            Temporal.Agua = double.Parse(Request.Form["Agua"]);
            Temporal.Alimento = double.Parse(Request.Form["Alimento"]);
            Temporal.PromedioHuevos = int.Parse(Request.Form["PromedioHuevos"]);
            Temporal.GallinasEnfermas = int.Parse(Request.Form["GallinasEnfermas"]);
            
            Temporal = _repoRegistro.AddRegistro(Temporal);
            Message = "Registro subido con exito";
            Message = $"ID referencia: {Temporal.Id_Registro}";
            CreateEntry = true;
        }
        public void OnPostRead()
        {
            personas = _repoPersona.GetAllPersona();
            registros = _repoRegistro.GetAllRegistro();

            searchID = Request.Form["lolaso"];
            
            searchQueried = true;
            
            //galpon = new Galpon();
            
            persona = _repoPersona.GetPersona(int.Parse(searchID));
            
            
           
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                Message = "Operario encontrado!"; 
                galpon = _repoGalpon.GetGalpon(persona.ID_GalponAsignado);
            }
            else
            {
                Message = "GOD FUCKING DAMMIT KRIS WHERE THE FUCK ARE WE!?";
            }
            
        }

        public void OnPostReadGalpon()
        {
            personas = _repoPersona.GetAllPersona();
            registros = _repoRegistro.GetAllRegistro();

            search = int.Parse(Request.Form["search"]);
            
            searchQueried2 = true;
            
            //galpon = new Galpon();
            
            persona = _repoPersona.GetPersona(1);
            
            
           
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                Message = "Operario encontrado!"; 
                galpon = _repoGalpon.GetGalpon(persona.ID_GalponAsignado);
            }
            else
            {
                Message = "GOD FUCKING DAMMIT KRIS WHERE THE FUCK ARE WE!?";
            }
        }
        public void OnPostUpdate_set()
        {
            // Temporal = new Persona();
            // Temporal.Id_Persona = int.Parse(Request.Form["Update_OperarioID"]);
            // Temporal.Nombre = Request.Form["Update_NombreOperario"];
            // Temporal.Telefono = int.Parse(Request.Form["Update_Telefono"]);
            // Temporal.Correo = Request.Form["Update_Correo"];
            // Temporal.ID_Rol = 1;
            // Temporal.Genero = Request.Form["Update_Genero"];
            // _repoPersona.UpdatePersona(Temporal);
            // Message = $"Operario #{Temporal.Id_Persona} Actualizado";
        }
        public void OnPostUpdate_get()
        {
            var searchID = Request.Form["TempID"];
            add = int.Parse(Request.Form["add"]);
            ID_Galpon = int.Parse(Request.Form["ID_Galpon"]);
            ID_Trabajador = int.Parse(Request.Form["ID_Trabajador"]);
            //persona = _repoPersona.GetPersona(int.Parse(searchID));
            galpon = _repoGalpon.GetGalpon(int.Parse(searchID));
            
            if (galpon != null)
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
