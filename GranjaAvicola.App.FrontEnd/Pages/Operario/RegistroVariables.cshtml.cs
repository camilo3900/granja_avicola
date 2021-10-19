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

        public Galpon galpon {get; set;}
        public Persona persona {get; set;}
        public Registro registro {get;set;}
        public Registro TemporalRegistro {get; set;}
        public IEnumerable<Registro> registros{get; set;}
        
        public string Message {get; set;} = "";
        
        public string searchID {get;set;}
        public bool found {get; set;} = false;
        public int state {get; set;} = 0;
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
        }
        public void OnPost()
        {

        }
        public void OnPostRead()
        {
            searchID = Request.Form["IDSearch"];
            persona = _repoPersona.GetPersona(int.Parse(searchID));
            
            if (persona != null && persona.ID_Rol.Equals(1) && persona.ID_GalponAsignado > 0)
            {
                Message = "Informacion:"; 
                galpon = _repoGalpon.GetGalpon(persona.ID_GalponAsignado);
            }
            else
            {
                Message = "No se encontro operario o no tiene galpón asignado aún";
            }
            found = true;
            state = 0;
        }
        public void OnPostCreateNew()
        {
            found = true;
            galpon = _repoGalpon.GetGalpon(int.Parse(Request.Form["ID_Galpon"]));
            persona = _repoPersona.GetPersona(int.Parse(Request.Form["ID_Operario"]));
            state = 1;
        }
        public void OnPostAddEntry()
        {
            found = true;
            galpon = _repoGalpon.GetGalpon(int.Parse(Request.Form["ID_Galpon"]));
            persona = _repoPersona.GetPersona(int.Parse(Request.Form["ID_Operario"]));
            
            TemporalRegistro = new Registro();
            state = 0;

            
            TemporalRegistro.ID_Trabajador = int.Parse(Request.Form["ID_Operario"]);
            TemporalRegistro.ID_Galpon = int.Parse(Request.Form["ID_Galpon"]);

            TemporalRegistro.FechaRegistro = DateTime.Now;

            TemporalRegistro.Temperatura = double.Parse(Request.Form["Temperatura"]);
            TemporalRegistro.Agua = double.Parse(Request.Form["Agua"]);
            TemporalRegistro.Alimento = double.Parse(Request.Form["Alimento"]);
            TemporalRegistro.PromedioHuevos = int.Parse(Request.Form["PromedioHuevos"]);
            TemporalRegistro.GallinasEnfermas = int.Parse(Request.Form["GallinasEnfermas"]);
            
            TemporalRegistro = _repoRegistro.AddRegistro(TemporalRegistro);
            Message = $"Registro {TemporalRegistro.Id_Registro} subido con exito";
            upload = true;
        }
        public void OnPostEntryHistory()
        {
            found = true;
            galpon = _repoGalpon.GetGalpon(int.Parse(Request.Form["ID_Galpon"]));
            persona = _repoPersona.GetPersona(int.Parse(Request.Form["ID_Operario"]));

            registros = _repoRegistro.GetAllRegistro();
            state = 2;
        }
    }
}