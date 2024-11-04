namespace Redarbor.Kafka.Eda.Interface;

public interface IKafkaConfig
{
    /// <summary>
    /// Server name, you can use many server divide to ;
    /// </summary>
    string StrapServers { get; set; }

    /// <summary>
    /// Group Id to consumers
    /// </summary>
    string GroupId { get; set; }
}
