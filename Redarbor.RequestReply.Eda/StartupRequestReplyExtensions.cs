using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redarbor.RequestReply.Eda.Interface;
using Redarbor.RequestReply.Eda.Persistence.Context;
using Redarbor.RequestReply.Eda.Persistence.Repository;
using Redarbor.RequestReply.Eda.Service;

namespace Redarbor.RequestReply.Eda;

public static class StartupRequestReplyExtensions
{
    public static IServiceCollection AddDependecyInjectionRequestReply(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddTransient<IRequestReplayRepository, RequestReplyRepository>();
        services.AddTransient<IRequestReplayService, RequestReplyService>();
        services.AddSingleton<RequestReplyContextDB>();
        return services;
    }
}