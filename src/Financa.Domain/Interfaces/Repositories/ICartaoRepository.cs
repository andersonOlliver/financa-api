using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Repositories
{
    public interface ICartaoRepository : IRepository<Cartao>
    {

        Task<IEnumerable<Cartao>> ObterTodosAsync(Guid usuarioId);
    }
}
