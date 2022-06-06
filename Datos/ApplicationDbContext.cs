using Entidades.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<FavoritosEModel> Favoritos { get; set; }
    }
}
