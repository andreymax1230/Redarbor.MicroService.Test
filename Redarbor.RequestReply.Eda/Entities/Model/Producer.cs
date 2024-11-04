using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Redarbor.RequestReply.Eda.Entities.Interfaces;

namespace Redarbor.RequestReply.Eda.Entities.Model;

public class Producer : IProducer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string EventId { get; set; }

    public string Topic { get; set; }
}
