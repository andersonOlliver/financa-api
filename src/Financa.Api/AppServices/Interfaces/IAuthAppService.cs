using Financa.Api.Models.Usuario;

namespace Financa.Api.AppServices.Interfaces
{
    public interface IAuthAppService
    {
        Task<DetalhaUsuarioDto> Registrar(AdicionaUsuarioDto novoUsuario);
        Task<LoginResponseDto> Autenticar(LoginRequestDto login);
    }
}
