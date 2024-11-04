namespace Redarbor.RequestReply.Eda.Entities.Interfaces;

public interface IProducer
{
    string Id { get; set; }

    public string EventId { get; set; }

    string Topic { get; set; }
}
