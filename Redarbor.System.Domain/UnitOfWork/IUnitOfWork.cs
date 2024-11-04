namespace Redarbor.System.Domain.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
}