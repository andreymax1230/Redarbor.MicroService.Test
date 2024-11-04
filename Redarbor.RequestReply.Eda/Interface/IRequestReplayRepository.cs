using Redarbor.RequestReply.Eda.Entities.Interfaces;

namespace Redarbor.RequestReply.Eda.Interface;

public interface IRequestReplayRepository
{
    Task GenerateRequestReplyAsync(IReply reply);

    Task<IReply> GetReplyByIdSessionAsync(string idSession, string topic);

    Task<long> HasReplyByIdSessionAsync(string idSession, string topic);

    Task DeleteReplyAsync(string idEvent);
}
