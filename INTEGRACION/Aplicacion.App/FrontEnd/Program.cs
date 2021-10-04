using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Aplicacion.App.Dominio;
using Aplicacion.App.Persistencia;

namespace FrontEnd
{
    public class Program
    {
        public static IRepositorioPersona _repoPersona= new RepositorioPersona(new Aplicacion.App.Persistencia.AppContext());
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //InsertarPersona();
            //_repoPersona.DeletePersona("1111");
            //_repoPersona.DeletePersona("55555");
        }
        private static void InsertarPersona()
        {
            var p=new Persona
            {
                Identificacion="1111",
                Nombre="Ana",
                Apellido="Alvarez",
                Genero="femenino",
                Estado='A'


            };
            _repoPersona.AddPersona(p);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
