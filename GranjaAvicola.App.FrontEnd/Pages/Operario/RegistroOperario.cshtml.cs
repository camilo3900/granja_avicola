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

        public Persona persona {get; set;}
        public Galpon galpon {get; set;}
        public Persona TemporalPersona {get; set;}

        public string[] Message = new string[] {"", "", "", ""};       

        public string searchID {get;set;}
        
        public bool searchQueried {get; set;} = false;
        public bool CreateEntry {get;set;} = false;
        public bool UpdateState {get; set;} = false;
        public bool UpdateEntry {get; set;} = false;
        public RegistroOperarioModel(IRepoPersona repoPersona, IRepoGalpon repoGalpon)
        {
            _repoPersona = repoPersona;
            _repoGalpon = repoGalpon;
        }
        public void OnGet()
        {
            persona = new Persona();
            Message[0] = "Registro";
        }
        public void OnPost(){}
        public void OnPostCreate()
        {
            Message[0] = "Registro";
            TemporalPersona = new Persona();
            galpon = new Galpon();
            TemporalPersona.Nombre = Request.Form["NombreOp"];
            TemporalPersona.Apellido = Request.Form["ApellidoOp"];
            TemporalPersona.Genero = Request.Form["GeneroOp"];
            TemporalPersona.Telefono = long.Parse(Request.Form["TelefonoOp"]);
            TemporalPersona.Correo = Request.Form["EmailOp"];
            TemporalPersona.ID_Rol = 1;
            

            galpon = _repoGalpon.GetGalpon(int.Parse(Request.Form["IDCargo"]));
            if (galpon != null)
            {
                TemporalPersona.ID_GalponAsignado = galpon.ID_Galpon;
                TemporalPersona = _repoPersona.AddPersona(TemporalPersona);
                
                galpon.ID_OperarioCargo = TemporalPersona.Id_Persona;
                
                galpon = _repoGalpon.UpdateGalpon(galpon);
                TemporalPersona = _repoPersona.UpdatePersona(TemporalPersona);
                
                Message[1] = "Operario subido con exito";
                Message[2] = $"ID referencia: {TemporalPersona.Id_Persona}";
                CreateEntry = true;
            }
            else
            {
                TemporalPersona.ID_GalponAsignado = 0;
                TemporalPersona = _repoPersona.AddPersona(TemporalPersona);

                Message[1] = "Operario subido con exito";
                Message[2] = $"ID referencia: {TemporalPersona.Id_Persona} Error al asignar Galpon";
                CreateEntry = true;
            }


        }
        public void OnPostRead()
        {
            Message[0] = "Registro";
            galpon = new Galpon();
            searchID = Request.Form["SearchID"];
            persona = _repoPersona.GetPersona(int.Parse(searchID));
           
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                galpon = _repoGalpon.GetGalpon(persona.ID_GalponAsignado);
                Message[3] = "Operario encontrado!"; 
                galpon = _repoGalpon.GetGalpon(persona.ID_GalponAsignado);
            }
            else
            {
                Message[3] = "Operario no encontrado.";
            }
            searchQueried = true;
        }
        public void OnPostUpdate_set()
        {
            Message[0] = "Registrar";
            TemporalPersona = new Persona();
            galpon = new Galpon();

            TemporalPersona.Id_Persona = int.Parse(Request.Form["Update_OperarioID"]);
            TemporalPersona.Nombre = Request.Form["Update_NombreOp"];
            TemporalPersona.Apellido = Request.Form["Update_ApellidoOp"];
            TemporalPersona.Genero = Request.Form["Update_GeneroOp"];
            TemporalPersona.Telefono = long.Parse(Request.Form["Update_TelefonoOp"]);
            TemporalPersona.Correo = Request.Form["Update_EmailOp"];
            TemporalPersona.ID_Rol = 1;

            galpon = _repoGalpon.GetGalpon(int.Parse(Request.Form["Update_IDCargo"]));
            if (galpon != null)
            {
                TemporalPersona.ID_GalponAsignado = galpon.ID_Galpon;
                galpon.ID_OperarioCargo = TemporalPersona.Id_Persona;
                
                galpon = _repoGalpon.UpdateGalpon(galpon);
                TemporalPersona = _repoPersona.UpdatePersona(TemporalPersona);
                
                Message[1] = "Operario actualizado con exito";
                Message[2] = $"Id Operario: {TemporalPersona.Id_Persona}";
                UpdateEntry = true;
            }
            else
            {
                TemporalPersona.ID_GalponAsignado = 0;
                
                TemporalPersona = _repoPersona.UpdatePersona(TemporalPersona);

                Message[1] = $"Operario {TemporalPersona.Id_Persona} actualizado con exito";
                Message[2] = "Error al asignar Galpon (Galpon no encontrado)";
                UpdateEntry = true;
            }

        }
        public void OnPostUpdate_get()
        {
            Message[0] = "Actualizar";
            var searchID = Request.Form["TempID"];
            persona = _repoPersona.GetPersona(int.Parse(searchID));
            UpdateState = true;
        }
        public void OnPostDelete()
        {
            Message[0] = "Registro";
            searchID = Request.Form["TempID"];
            persona = _repoPersona.DeletePersona(int.Parse(searchID));
            UpdateEntry = true;
            if (persona != null && persona.ID_Rol.Equals(1))
            {
                if(persona.ID_GalponAsignado > 0)
                {
                    galpon = new Galpon();
                    galpon = _repoGalpon.GetGalpon(persona.ID_GalponAsignado);
                    galpon.ID_OperarioCargo = 0;
                    galpon = _repoGalpon.UpdateGalpon(galpon);
                }
                Message[1] = "Operario eliminado con exito!";
            }
            else
            {
                Message[1] = "El Operario no existe";
            }
        }
    }
}
