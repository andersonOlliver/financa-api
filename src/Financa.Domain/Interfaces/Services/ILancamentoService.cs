using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Services
{
    public interface ILancamentoService
    { 

        Task<Lancamento> Adicionar(Lancamento lancamento);
        Task<Lancamento> Atualizar(Guid id, Lancamento lancamento);
        Task<IEnumerable<Lancamento>> ObterTodos();
        Task<Lancamento?> ObterPorId(Guid id);
        Task Remover(Guid id);
    }
}
