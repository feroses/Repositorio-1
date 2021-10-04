using System;
using System.Linq;
using Aplicacion.App.Dominio;
using System.Collections.Generic;
namespace Aplicacion.App.Persistencia
{
    public class RepositorioPersona: IRepositorioPersona
    {
        private readonly AppContext _appContext;
        public RepositorioPersona(AppContext appContext)
        {
            _appContext=appContext;
        }

        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var personaAdicionada=_appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return personaAdicionada.Entity;
        }

        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personaEncontrada=_appContext.Personas.FirstOrDefault(p=>  p.Identificacion==persona.Identificacion);
            if(personaEncontrada!=null)
            {
                personaEncontrada.Identificacion=persona.Identificacion;
                personaEncontrada.Nombre=persona.Nombre;
                personaEncontrada.Apellido=persona.Apellido;
                _appContext.SaveChanges();
            }
            return personaEncontrada;
        }

        Persona IRepositorioPersona.GetPersona(string identificacionpersona)
        {
            var personaEncontrada=_appContext.Personas.FirstOrDefault(p=> p.Identificacion==identificacionpersona);
            return personaEncontrada;
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas()
        {
            return _appContext.Personas;
        }

        Persona IRepositorioPersona.DeletePersona(string identificacionpersona) 
        {
            var personaEncontrada=_appContext.Personas.FirstOrDefault(p=> p.Identificacion==identificacionpersona);
            if(personaEncontrada!=null)
            {
                _appContext.Personas.Remove(personaEncontrada);
                _appContext.SaveChanges();
            }
            return personaEncontrada; 
        }

    }
}
