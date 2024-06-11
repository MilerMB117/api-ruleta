using Microsoft.EntityFrameworkCore;
using api_ruleta.Models;

namespace api_ruleta.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Saldo)
                .HasColumnType("decimal(18,2)"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
