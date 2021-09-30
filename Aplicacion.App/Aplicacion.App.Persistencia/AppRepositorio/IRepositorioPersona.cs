using System;
using System.Linq;
using Aplicacion.App.Dominio;
using System.Collections.Generic;
namespace Aplicacion.App.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> GetAllPersonas();
        Persona AddPersona(Persona persona);
        Persona UpdatePersona(Persona persona);
        Persona GetPersona(string identificacionpersona);
        Persona DeletePersona(string identificacionpersona);
    }
}
