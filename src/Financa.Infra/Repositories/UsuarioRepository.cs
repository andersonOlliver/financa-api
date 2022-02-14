using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Repositories
{
    public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FinancaContext context) : base(context) {}

        public async Task<Usuario?> BuscarPorEmail(string email)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailJaCadastrado(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }
    }
}

