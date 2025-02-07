using InfrastructureLayer.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.ConfigureDatabase();
            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
        {
            var databaseType = configuration.GetValue<string>("DatabaseType");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                switch (databaseType)
                {
                    case "InMemory":
                        options.UseInMemoryDatabase("TestDb");
                        break;
                    case "SQLite":
                        options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"));
                        break;
                    case "MySQL":
                        options.UseMySql(configuration.GetConnectionString("MySQLConnection"),
                            new MySqlServerVersion(new Version(8, 0, 25)));
                        break;
                    default:
                        throw new Exception("Adatbázis típust meg kell adni a konfigurációban.");
                }
            });

            return services;
        }
    }
}
