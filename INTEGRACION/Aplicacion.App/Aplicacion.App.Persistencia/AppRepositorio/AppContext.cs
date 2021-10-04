using Microsoft.EntityFrameworkCore;
using Aplicacion.App.Dominio;
namespace Aplicacion.App.Persistencia
{
    public class  AppContext:DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Estacion> Estaciones {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=nombrebasedatos");
            }
        }
    }
}