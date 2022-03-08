using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnityOfWork { get; }

        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T?> ObterPorId(Guid id);
        Task<T?> ObterPorId(Guid id, bool track = false);
        Task<T> Adicionar(T lancamento);
        Task<T> Atualizar(T lancamento);
        Task Remover(T lancamento);
    }
}
