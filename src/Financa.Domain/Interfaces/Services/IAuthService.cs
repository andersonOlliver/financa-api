using Financa.Domain.Dtos.Auth;
using Financa.Domain.Dtos.Usuario;

namespace Financa.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<DetalhaUsuarioDto> Registrar(AdicionaUsuarioDto novoUsuario);
        Task<LoginResponseDto> Autenticar(LoginRequestDto login);
    }
}
