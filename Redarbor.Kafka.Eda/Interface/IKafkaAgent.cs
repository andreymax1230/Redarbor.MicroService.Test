namespace Redarbor.Kafka.Eda.Interface;

public interface IKafkaAgent
{
    /// <summary>
    /// Suscribe topic to broker, execute handler intance for interface implement IKafkaEvent, to integrator library 
    /// </summary>
    /// <returns>Task action</returns>
    Task Subscribe();
}
