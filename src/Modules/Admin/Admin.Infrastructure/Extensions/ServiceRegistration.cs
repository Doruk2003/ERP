using Admin.Application.Abstractions.Persistence;
using Admin.Infrastructure.Persistence;
using Admin.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddAdminInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<AdminMongoContext>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
