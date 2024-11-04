using Redarbor.RequestReply.Eda.Entities.Interfaces;
using Redarbor.RequestReply.Eda.Entities.Model;
using Redarbor.RequestReply.Eda.Interface;
using Redarbor.RequestReply.Eda.Persistence.Context;
using MongoDB.Driver;

namespace Redarbor.RequestReply.Eda.Persistence.Repository;

public class RequestReplyRepository : IRequestReplayRepository
{
    private readonly RequestReplyContextDB _context;

    public RequestReplyRepository(RequestReplyContextDB context)
    {
        _context = context;
    }
    public Task GenerateRequestReplyAsync(IReply reply) => _context.reply.InsertOneAsync(reply as Reply);

    public Task DeleteReplyAsync(string idEvent) => _context.reply.DeleteManyAsync(x => x.EventId == idEvent);

    public async Task<IReply> GetReplyByIdSessionAsync(string idEvent, string topic) => _context.reply.FindAsync(x => x.EventId == idEvent && x.Topic == topic).Result.FirstOrDefault() as IReply;

    public Task<long> HasReplyByIdSessionAsync(string idEvent, string topic) => Task.Factory.StartNew(() => _context.reply.CountDocuments(x => x.EventId == idEvent && x.Topic == topic));
}
