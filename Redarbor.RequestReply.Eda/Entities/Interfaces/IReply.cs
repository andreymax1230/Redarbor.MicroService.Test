namespace Redarbor.RequestReply.Eda.Entities.Interfaces;

public interface IReply
{
    public string EventId { get; set; }

    string? Id { get; set; }

    string Topic { get; set; }

    string Payload { get; set; }

    DateTime DateCreate { get; set; }
}