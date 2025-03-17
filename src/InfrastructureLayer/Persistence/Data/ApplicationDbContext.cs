using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Migráció során az adatbázisba kerülő adatok
            modelBuilder.Entity<Profile>().HasData(
                new Profile(Guid.NewGuid()) { Name = "John Doe", Email = "john.doe@example.com" },
                new Profile(Guid.NewGuid()) { Name = "Jane Smith", Email = "jane.smith@example.com" }
            );

            // Konfogurációs adatok betöltése az assambly-ből, pl. ProfileConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
