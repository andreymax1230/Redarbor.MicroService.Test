using Redarbor.System.Domain.Repositories;
using Redarbor.System.Domain.UnitOfWork;
using Redarbor.System.Infraestructure;

namespace Redarbor.Presentation.Api.Infraestructure;

public static class RegisterDependency
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }
}