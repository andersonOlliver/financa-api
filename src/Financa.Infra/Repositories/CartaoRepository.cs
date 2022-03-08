using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Repositories
{
    public class CartaoRepository : BaseRepository<Cartao>, ICartaoRepository
    {
        public CartaoRepository(FinancaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cartao>> ObterTodosAsync(Guid usuarioId)
        {
            return await _context.Cartoes.Where(c => c.UsuarioId == usuarioId)
                .OrderBy(c => c.DiaVencimento)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

