using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Services
{
    public interface IAbstractService<E, A, L, D> where E: Entity
    {
        Task<D> AdicionaAsync(A modeldto);
        Task<D> AtualizaAsync(Guid id, D modeldto);
        Task<D> ObterPorId(Guid id);
        Task<ICollection<L>> ObterTodosAsync();
        Task RemoverAsync(Guid id);
    }
}