using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;

namespace Financa.Domain.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Lancamento> Adicionar(Lancamento lancamento)
        {
            await _lancamentoRepository.Adicionar(lancamento);
            await _lancamentoRepository.UnityOfWork.CommitAsync();
            return lancamento;
        }

        public async Task<Lancamento> Atualizar(Guid id, Lancamento lancamento)
        {
            var fromDB = await ObterPorId(id);
            if (fromDB is null)
            {
                throw new ApplicationException("Lançamento informado inválido");
            }

            await _lancamentoRepository.Atualizar(lancamento);
            await _lancamentoRepository.UnityOfWork.CommitAsync();
            return lancamento;
        }

        public async Task<Lancamento?> ObterPorId(Guid id)
        {
            return await _lancamentoRepository.ObterPorId(id);
        }

        public Task<IEnumerable<Lancamento>> ObterTodos()
        {
            return _lancamentoRepository.ObterTodosAsync();
        }

        public async Task Remover(Guid id)
        {
            var lancamento = await ObterPorId(id);
            if (lancamento == null)
            {
                throw new ApplicationException("Lançamento informado inválido");
            }

            await _lancamentoRepository.Remover(lancamento);
            await _lancamentoRepository.UnityOfWork.CommitAsync();
        }
    }
}
