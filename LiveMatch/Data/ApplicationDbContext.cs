using LiveMatch.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveMatch.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Modelos

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Estadio> Estadio { get; set; }

        public DbSet<Deporte> Deporte { get; set; }

        public DbSet<CondicionPago> CondicionPagos { get; set; }

        public DbSet<Parcialidad> Parcialidades { get; set; }

        public DbSet<TipoEspectador> TipoEspectadores { get; set; }
        public DbSet<UbicacionEstadio> UbicacionesEstadio { get; set; }
        public DbSet<Entrada> Entradas { get; set; }


    }
}
