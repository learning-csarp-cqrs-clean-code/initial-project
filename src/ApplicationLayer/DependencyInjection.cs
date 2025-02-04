using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer
{
    public  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assambly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assambly));
            return services;
        }
    }
}
