using InfrastructureLayer.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            //var databaseType = configuration.GetValue<string>("DatabaseType");

            string databaseType = "InMemory";

            switch (databaseType)
            {
                case "InMemory":
                    services.ConfigureInMemoryDatabase();
                    break;
                /*case "SQLite":
                    options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"));
                    break;
                case "MySQL":
                    options.UseMySql(configuration.GetConnectionString("MySQLConnection"),
                        new MySqlServerVersion(new Version(8, 0, 25)));
                    break;*/
                default:
                    throw new Exception("Adatbázis típust meg kell adni a konfigurációban.");
            }
            return services;
        }

        public static void ConfigureInMemoryDatabase(this IServiceCollection services)
        {
            string dbName = "TestDb";
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseInMemoryDatabase(databaseName: dbName);
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                }
            );
        }
    }
}
