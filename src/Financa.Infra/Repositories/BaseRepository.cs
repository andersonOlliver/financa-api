using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {

        protected readonly FinancaContext _context;

        protected BaseRepository(FinancaContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnityOfWork => _context;

        public async virtual Task<T> Adicionar(T model)
        {

            await _context.Set<T>().AddAsync(model); ;
            return model;
        }

        public async Task<T> Atualizar(T model)
        {
            model.NovaDataAtualizacao();
            _context.Set<T>().Update(model);
            return await Task.FromResult(model);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async virtual Task<T?> ObterPorId(Guid id, bool track = false)
        {
            return track ?
               await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id) :
                await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<T?> ObterPorId(Guid id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Remover(T model)
        {
            await Task.FromResult(_context.Set<T>().Remove(model));
        }
    }
}

