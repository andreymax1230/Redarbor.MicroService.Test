using Redarbor.Kafka.Eda.Model;

namespace Redarbor.Kafka.Eda.Interface;

public interface IKafkaEvent
{
    /// <summary>
    /// Execute method for integrator library, trigger the mediator MediatR business (Application)
    /// </summary>
    /// <param name="result">Result server</param>
    /// <param name="token">cancel token</param>
    /// <returns>Executed Task</returns>
    Task Handler(KafkaMessage meesage, CancellationToken token);
}
