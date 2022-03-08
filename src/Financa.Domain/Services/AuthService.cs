using AutoMapper;
using Financa.Domain.Dtos.Auth;
using Financa.Domain.Dtos.Usuario;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Services;

namespace Financa.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly IJwtService _jwtUtil;

        public AuthService(IMapper mapper, IUsuarioService usuarioService, IJwtService jwtUtil)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
            _jwtUtil = jwtUtil;
        }

        public async Task<LoginResponseDto> Autenticar(LoginRequestDto login)
        {
            var usuario = await _usuarioService.Buscar(login.Email, login.Senha);
            var (token, expires) = _jwtUtil.GenerateToken(usuario);
            return new LoginResponseDto
            {
                Token = token,
                ExpiresIn = expires,
            };
        }

        public async Task<DetalhaUsuarioDto> Registrar(AdicionaUsuarioDto novoUsuario)
        {
            var usuario = _mapper.Map<AdicionaUsuarioDto, Usuario>(novoUsuario);
            var usuarioRegistrado = await _usuarioService.Registrar(usuario);
            return _mapper.Map<DetalhaUsuarioDto>(usuarioRegistrado);
        }
    }
}
