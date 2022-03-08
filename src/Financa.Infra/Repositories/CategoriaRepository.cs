using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(FinancaContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Categoria>> ObterTodosAsync()
        {
            return await _context.Categorias.AsNoTracking()
                .OrderByDescending(c => c.DataCadastro)
                                             .ToListAsync();
        }
    }
}

