using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Repositories
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(FinancaContext context): base(context)
        {
        }

        public async override Task<IEnumerable<Lancamento>> ObterTodosAsync()
        {
            return await _context.Lancamentos.AsNoTracking()
                                             .Include(c => c.Categoria)
                                             .ToListAsync();
        }

        public async override Task<Lancamento?> ObterPorId(Guid id)
        {
            return await _context.Lancamentos.AsNoTracking()
                                             .Include(c => c.Categoria)
                                             .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

