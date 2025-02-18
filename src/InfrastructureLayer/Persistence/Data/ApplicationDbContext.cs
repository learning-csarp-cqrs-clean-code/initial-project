using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Profil> Profiles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profil>().HasData(
                new Profil(Guid.NewGuid()) { Name = "John Doe", Email = "john.doe@example.com" },
                new Profil(Guid.NewGuid()) { Name = "Jane Smith", Email = "jane.smith@example.com" }
            );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
