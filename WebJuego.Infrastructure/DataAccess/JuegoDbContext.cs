using Microsoft.EntityFrameworkCore;
using WebJuego.Domain.Entities;

namespace WebJuego.Infrastructure.DataAccess
{
    public class JuegoDbContext : DbContext
    {
        public JuegoDbContext(DbContextOptions<JuegoDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Jugadores> Jugadores { get; set; }
    }
}
