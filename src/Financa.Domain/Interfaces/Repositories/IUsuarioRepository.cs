using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository: IRepository<Usuario> {
        Task<bool> EmailJaCadastrado(string email);
        Task<Usuario?> BuscarPorEmail(string email);
    }
}
