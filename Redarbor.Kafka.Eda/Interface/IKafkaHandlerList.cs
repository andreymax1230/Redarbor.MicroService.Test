namespace Redarbor.Kafka.Eda.Interface;

public interface IKafkaHandlerList
{
    /// <summary>
    /// Add eda Event
    /// </summary>
    /// <param name="kafkaEdaType">Type Eda</param>
    void Add(Type type);

    /// <summary>
    /// Return list events suscribe
    /// </summary>
    /// <returns></returns>
    Dictionary<string, List<Type>> GetEvents();
}