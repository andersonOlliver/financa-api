using Financa.Api.Models.Lancamento;

namespace Financa.Api.AppServices.Interfaces
{
    public interface ILancamentoAppService
    {
        Task<LancamentoDto> Adicionar(AdicionaLancamentoDto lancamentoDto);
        Task<LancamentoDto> Atualizar(Guid id, LancamentoDto lancamentoDto);
        Task<DetalhaLancamentoDto> ObterPorId(Guid id);
        Task<ICollection<LancamentoDto>> ObterTodos();
        Task Remover(Guid id);
    }
}