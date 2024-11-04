using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Redarbor.System.Integrator;

public static class RegisterDependency
{
    public static IServiceCollection AddIntegrator(this IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
