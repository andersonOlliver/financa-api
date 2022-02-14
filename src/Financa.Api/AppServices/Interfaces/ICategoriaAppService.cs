using Financa.Api.Models;

namespace Financa.Api.AppServices.Interfaces
{
    public interface ICategoriaAppService
    {
        Task<CategoriaDto> AdicionaAsync(AdicionaCategoriaDto categoriaDto);
        Task<CategoriaDto> AtualizaAsync(Guid id, CategoriaDto categoriaDto);
        Task<DetalhaCategoriaDto> ObterPorId(Guid id);
        Task<ICollection<CategoriaDto>> ObterTodosAsync();
        Task RemoverAsync(Guid id);
    }
}