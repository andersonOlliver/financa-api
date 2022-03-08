using AutoMapper;
using Financa.Domain.Dtos.Cartao;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;

namespace Financa.Domain.Services
{
    public class CartaoService : AbstractService<Cartao, AdicionaCartaoDto, ListaCartaoDto, DetalhaCartaoDto>, ICartaoService
    {
        public CartaoService(IMapper mapper, ICartaoRepository repository) : base(mapper, repository)
        {
        }

        public async Task<DetalhaCartaoDto> AdicionaAsync(AdicionaCartaoDto modelDto, Guid usuarioId)
        {
            var model = _mapper.Map<Cartao>(modelDto);
            model.UsuarioId = usuarioId;

            await _repository.Adicionar(model);
            await _repository.UnityOfWork.CommitAsync();
            return _mapper.Map<DetalhaCartaoDto>(model);
        }
    }
}
