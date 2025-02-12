using DomainLayer.Commons;
using InfrastructureLayer.Persistence.Data;

namespace InfrastructureLayer.Persistence.Seed
{
    public static class InitialDataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Profiles.Any())
            {
                context.Profiles.AddRange(
                    new Profile(Guid.NewGuid()) { Name = "John Doe", Email = "john.doe@example.com" },
                    new Profile(Guid.NewGuid()) { Name = "Jane Smith", Email = "jane.smith@example.com" }
                );

                context.SaveChanges();
            }
        }
    }
}
