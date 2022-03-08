using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Repositories
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(FinancaContext context) : base(context)
        {
        }

        public override Task<Lancamento> Adicionar(Lancamento model)
        {
            model.Categoria = _context.Categorias.Find(model.CategoriaId) ?? model.Categoria;
            return base.Adicionar(model);
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

        public async Task<IEnumerable<Lancamento>> ObterTodosAsync(Guid usuarioId)
        {
            return await _context.Lancamentos.AsNoTracking()
                                             .Include(c => c.Categoria)
                                             .Where(e => e.UsuarioId == usuarioId)
                                             .ToListAsync();
        }
    }
}

