using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Redarbor.System.Infraestructure;

public static class StartupExtensions
{
    public static IApplicationBuilder InitializeBD(this IApplicationBuilder builder)
    {
        InitializData(builder.ApplicationServices);
        return builder;
    }

    private static void InitializData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Entities>();
        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }
}