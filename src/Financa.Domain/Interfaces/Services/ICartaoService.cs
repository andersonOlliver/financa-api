using Financa.Domain.Dtos.Cartao;
using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Services
{
    public interface ICartaoService : IAbstractService<Cartao, AdicionaCartaoDto, ListaCartaoDto, DetalhaCartaoDto>
    {
        Task<DetalhaCartaoDto> AdicionaAsync(AdicionaCartaoDto cartaoDto, Guid usuarioId);
    }
}