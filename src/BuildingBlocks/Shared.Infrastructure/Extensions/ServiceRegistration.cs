using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Abstractions;
using Shared.Application.Behaviors;
using Shared.Infrastructure.Mongo;

namespace Shared.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddSharedInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));

        services.AddSingleton(sp =>
        {
            var settings =
                sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<MongoSettings>>().Value;

            return new MongoContext(settings);
        });

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        return services;
    }
}
