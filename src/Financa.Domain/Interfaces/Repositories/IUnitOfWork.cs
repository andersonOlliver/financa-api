namespace Financa.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
