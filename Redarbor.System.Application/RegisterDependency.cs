using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Redarbor.System.Application.Common;
using System.Reflection;

namespace Redarbor.System.Application;

public static class RegisterDependency
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
