using Financa.Domain.Dtos.Lancamento;
using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Services
{
    public interface ILancamentoService : IAbstractService<Lancamento, AdicionaLancamentoDto, LancamentoDto, DetalhaLancamentoDto>
    {
        Task<LancamentoDto> Adicionar(AdicionaLancamentoDto lancamentoDto, Guid? usuarioId);
        Task<LancamentoDto> Adicionar(AdicionaDespesaDto lancamentoDto, Guid? usuarioId);
        Task<ICollection<LancamentoDto>> ObterTodos(Guid usuarioId);
    }
}