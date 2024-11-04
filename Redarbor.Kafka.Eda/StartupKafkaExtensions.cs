using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Redarbor.Kafka.Eda.Agent;
using Redarbor.Kafka.Eda.Configuration;
using Redarbor.Kafka.Eda.Handler;
using Redarbor.Kafka.Eda.Interface;
using Redarbor.Kafka.Eda.Services;
using System.Reflection;

namespace Redarbor.Kafka.Eda;

public static class StartupKafkaExtensions
{
    #region public
    public static IServiceCollection InitializeKafkaServices(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
    {
        AddMessageKafka(services, assemblies);
        services.AddSingleton<IKafkaAgent, KafkaAgent>();
        services.AddSingleton<IKafkaProducerService, KafkaProducerService>();
        services.AddTransient<IKafkaConfig, KafkaConfig>();
        services.AddSingleton<IMongoClient>(s => new MongoClient(configuration.GetConnectionString("DefaultConnectionRequestReply")));
        services.AddTransient((service) =>
        {
            return new AdminClientBuilder(AddConfigurationKafka(configuration)).Build();
        });
        services.AddTransient((service) =>
        {
            return new ConsumerBuilder<Ignore, string>(AddConfigurationKafka(configuration)).Build();
        });
        services.AddTransient((service) =>
        {
            return new ProducerBuilder<Null, string>(AddConfigurationKafka(configuration)).Build();
        });
        return services;
    }
    #endregion

    #region private
    private static IServiceCollection AddMessageKafka(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddSingleton<IKafkaHandlerList>(new KafkaHandlerList(services, assemblies));
        return services;
    }

    private static ConsumerConfig AddConfigurationKafka(IConfiguration configuration)
    {
        var setting = configuration.GetRequiredSection("Kafka").Get<KafkaConfig>();
        var maxLengthGroupId = 248;
        string groupId = $"{setting!.GroupId}_{Guid.NewGuid()}";
        if (groupId.Length > maxLengthGroupId)
        {
            groupId = groupId.Substring(0, 248);
        }
        var config = new ConsumerConfig
        {
            BootstrapServers = setting.StrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Latest,
            EnableAutoCommit = false
        };
        if (setting?.MessageMaxBytes != 0)
        {
            config.MessageMaxBytes = setting!.MessageMaxBytes;
            config.MaxPartitionFetchBytes = setting.MessageMaxBytes;
        }

        return config;
    }
    #endregion

    public static IHost UseHostKafka(this IHost app)
    {
        var dispacher = app.Services.GetService<IKafkaProducerService>();
        ArgumentNullException.ThrowIfNull(dispacher);
        dispacher.SuscribeBuild();
        return app;
    }
}