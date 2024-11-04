namespace Redarbor.Kafka.Eda.Attribute;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class KafkaTopicAttribute : System.Attribute
{
    /// <summary>
    /// Name event topic
    /// </summary>
    public string Topic { get; private set; }

    /// <summary>
    /// Constructor base Kafka topic
    /// </summary>
    /// <param name="topic">Name event to subcribed</param>
    public KafkaTopicAttribute(string topic)
    {
        Topic = topic;
    }
}
