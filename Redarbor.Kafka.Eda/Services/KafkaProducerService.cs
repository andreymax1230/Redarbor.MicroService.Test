using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Redarbor.Kafka.Eda.Interface;
using Redarbor.Kafka.Eda.Utilities;

namespace Redarbor.Kafka.Eda.Services;

public class KafkaProducerService : IKafkaProducerService, IDisposable
{
    private readonly IProducer<Null, string> _producerKafka;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Constructor base
    /// </summary>
    /// <param name="configurationBroker">Configuration Broker</param>
    /// <param name="serviceProvider">Service Dependency Injection</param>
    /// <param name="configurationSettings">Information Appsettings</param>
    public KafkaProducerService(IProducer<Null, string> producerKafka, IServiceProvider serviceProvider)
    {
        _producerKafka = producerKafka;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Suscribe Topics and consumer events
    /// </summary>
    public void SuscribeBuild()
    {
        IKafkaAgent kafkaAgent = _serviceProvider.GetService<IKafkaAgent>();
        ArgumentNullException.ThrowIfNull(kafkaAgent);
        kafkaAgent.Subscribe();
    }

    /// <summary>
    /// Send message Kafka
    /// </summary>
    /// <param name="topic">Topic Name</param>
    /// <param name="payload">Message</param>
    /// <returns></returns>
    public Task PublishAsync(string topic, object value) => Task.Factory.StartNew(async () =>
    {
        await _producerKafka.ProduceAsync(topic, new Message<Null, string> { Value = value.ToSerializeJSON() });
    });

    public void Dispose() => _producerKafka.Dispose();
}