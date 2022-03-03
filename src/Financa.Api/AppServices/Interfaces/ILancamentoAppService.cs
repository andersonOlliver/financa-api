using Financa.Api.Models.Lancamento;

namespace Financa.Api.AppServices.Interfaces
{
    public interface ILancamentoAppService
    {
        Task<LancamentoDto> Adicionar(AdicionaLancamentoDto lancamentoDto, Guid? usuarioId);
        Task<LancamentoDto> Atualizar(Guid id, LancamentoDto lancamentoDto);
        Task<DetalhaLancamentoDto> ObterPorId(Guid id);
        Task<ICollection<LancamentoDto>> ObterTodos();
        Task<ICollection<LancamentoDto>> ObterTodos(Guid usuarioId);
        Task Remover(Guid id);
    }
}