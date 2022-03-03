using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> Registrar(Usuario usuario);
        //Task<UsuarioRegistradoDto> Registrar(NovoUsuarioDto novoUsuario, string origem);
        Task<Usuario> Buscar(string email, string senha);
    }
}
