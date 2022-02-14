using AutoMapper;
using Financa.Api.AppServices.Interfaces;
using Financa.Api.Models;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;

namespace Financa.Api.AppServices
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<DetalhaCategoriaDto> ObterPorId(Guid id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);
            return _mapper.Map<DetalhaCategoriaDto>(categoria);
        }

        public async Task<ICollection<CategoriaDto>> ObterTodosAsync()
        {
            var categorias = await _categoriaRepository.ObterTodosAsync();
            return _mapper.Map<ICollection<CategoriaDto>>(categorias);
        }

        public async Task<CategoriaDto> AdicionaAsync(AdicionaCategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.Adicionar(categoria);
            await _categoriaRepository.UnityOfWork.CommitAsync();
            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task<CategoriaDto> AtualizaAsync(Guid id, CategoriaDto categoriaDto)
        {
            var fromDb = await _categoriaRepository.ObterPorId(id);
            if (fromDb is null || !id.Equals(categoriaDto.Id))
            {
                throw new ApplicationException("Categoria inválida");
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.Atualizar(categoria);
            await _categoriaRepository.UnityOfWork.CommitAsync();
            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task RemoverAsync(Guid id)
        {
            var fromDb = await _categoriaRepository.ObterPorId(id);
            if (fromDb is null)
            {
                throw new ApplicationException("Categoria inválida");
            }

            await _categoriaRepository.Remover(fromDb);
            await _categoriaRepository.UnityOfWork.CommitAsync();
        }
    }
}
