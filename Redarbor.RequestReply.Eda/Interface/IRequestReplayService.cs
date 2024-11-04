using Redarbor.Domain.Eda.Interface.DTOs;
using Redarbor.Kafka.Eda.Interface;

namespace Redarbor.RequestReply.Eda.Interface;

public interface IRequestReplayService : IKafkaEvent
{
    Task<T> WaitProducer<T>(IPayloadMessageDTO payload, string startTopic, string endTopic, TimeSpan? timeout);
}