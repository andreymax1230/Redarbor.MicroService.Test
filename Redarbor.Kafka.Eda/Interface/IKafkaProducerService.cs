namespace Redarbor.Kafka.Eda.Interface;

public interface IKafkaProducerService
{
    /// <summary>
    /// Send request from app to kafka's server
    /// </summary>
    /// <param name="topic">Name event for subscribe</param>
    /// <param name="payload">objet send to kafka</param>
    /// <returns></returns>
    Task PublishAsync(string topic, object value);

    /// <summary>
    /// Suscribe Topics and consumer events
    /// </summary>
    void SuscribeBuild();
}
