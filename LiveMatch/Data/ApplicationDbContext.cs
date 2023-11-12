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
    }
}
