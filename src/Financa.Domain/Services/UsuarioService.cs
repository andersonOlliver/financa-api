using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financa.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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
