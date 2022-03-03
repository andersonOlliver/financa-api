using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Repositories
{
    public interface ILancamentoRepository:IRepository<Lancamento>
    {
        Task<IEnumerable<Lancamento>> ObterTodosAsync(Guid UsuarioId);
    }
}
