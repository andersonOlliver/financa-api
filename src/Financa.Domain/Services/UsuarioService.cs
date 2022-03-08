using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Financa.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Buscar(string email, string senha)
        {
            var usuario = await _usuarioRepository.BuscarPorEmail(email);

            if (usuario is null || !BCryptNet.Verify(senha, usuario.Senha))
                throw new ApplicationException("Usuario ou senha incorreto");

            return usuario;
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            if (await _usuarioRepository.EmailJaCadastrado(usuario.Email))
            {
                throw new ApplicationException("E-mail já cadastrado");
            }

            await _usuarioRepository.Adicionar(usuario);
            await _usuarioRepository.UnityOfWork.CommitAsync();
            return usuario;
        }
    }
}
