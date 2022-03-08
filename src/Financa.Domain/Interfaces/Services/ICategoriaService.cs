using Financa.Domain.Dtos;

namespace Financa.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> AdicionaAsync(AdicionaCategoriaDto categoriaDto);
        Task<CategoriaDto> AtualizaAsync(Guid id, CategoriaDto categoriaDto);
        Task<DetalhaCategoriaDto> ObterPorId(Guid id);
        Task<ICollection<CategoriaDto>> ObterTodosAsync();
        Task RemoverAsync(Guid id);
    }
}