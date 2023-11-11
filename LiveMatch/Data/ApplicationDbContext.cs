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

        //Modelos

        public DbSet<LiveMatch.Models.Estadio> Estadio { get; set; } = default!;

        //Modelos

        public DbSet<LiveMatch.Models.Deporte> Deporte { get; set; } = default!;
    }
}
