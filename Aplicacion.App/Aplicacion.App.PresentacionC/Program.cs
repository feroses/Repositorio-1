using System;
using Aplicacion.App.Dominio;
using Aplicacion.App.Persistencia;
namespace Aplicacion.App.PresentacionC
{
    class Program
    {
        private static IRepositorioPersona _repoPersona= new RepositorioPersona(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio de Pruebas!");
            InsertarPersona();
            Console.WriteLine("OK!");
        }

        private static void InsertarPersona()
        {
            var p=new Persona
            {
                Identificacion="55555",
                Nombre="Federrico",
                Apellido="candamil",
                Genero="Masculino",
                Estado='A'


            };
            _repoPersona.AddPersona(p);
        }
    }
}
