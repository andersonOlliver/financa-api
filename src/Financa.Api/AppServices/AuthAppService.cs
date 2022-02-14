using AutoMapper;
using Financa.Api.AppServices.Interfaces;
using Financa.Api.Models.Usuario;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Services;

namespace Financa.Api.AppServices
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public AuthAppService(IMapper mapper, IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public Task<DetalhaUsuarioDto> Autenticar(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public async Task<DetalhaUsuarioDto> Registrar(AdicionaUsuarioDto novoUsuario)
        {
            var usuario = _mapper.Map<AdicionaUsuarioDto, Usuario>(novoUsuario);
            var usuarioRegistrado = await _usuarioService.Registrar(usuario);
            return _mapper.Map<DetalhaUsuarioDto>(usuarioRegistrado);
        }
    }
}
