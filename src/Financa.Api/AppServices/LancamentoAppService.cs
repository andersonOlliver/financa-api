using AutoMapper;
using Financa.Api.AppServices.Interfaces;
using Financa.Api.Models.Lancamento;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;

namespace Financa.Api.AppServices
{
    public class LancamentoAppService : ILancamentoAppService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IMapper _mapper;

        public LancamentoAppService(ILancamentoRepository lancamentoRepository, IMapper mapper)
        {
            _lancamentoRepository = lancamentoRepository;
            _mapper = mapper;
        }

        public async Task<LancamentoDto> Adicionar(AdicionaLancamentoDto lancamentoDto, Guid? usuarioId)
        {
            if (usuarioId is null) throw new ApplicationException("Deve informar um usuario");

            var lancamento = _mapper.Map<Lancamento>(lancamentoDto);
            lancamento.UsuarioId = usuarioId.Value;
            await _lancamentoRepository.Adicionar(lancamento);
            await _lancamentoRepository.UnityOfWork.CommitAsync();

            return _mapper.Map<LancamentoDto>(lancamento);
        }

        public async Task<LancamentoDto> Atualizar(Guid id, LancamentoDto lancamentoDto)
        {
            var fromDB = await _lancamentoRepository.ObterPorId(id);
            if (fromDB is null)
            {
                throw new ApplicationException("Lançamento informado inválido");
            }

            var lancamento = _mapper.Map<Lancamento>(lancamentoDto);
            await _lancamentoRepository.Atualizar(lancamento);
            await _lancamentoRepository.UnityOfWork.CommitAsync();
            return _mapper.Map<LancamentoDto>(lancamento);
        }

        public async Task<DetalhaLancamentoDto> ObterPorId(Guid id)
        {
            var lancamento = await _lancamentoRepository.ObterPorId(id);
            return _mapper.Map<DetalhaLancamentoDto>(lancamento);
        }

        public async Task<ICollection<LancamentoDto>> ObterTodos()
        {
            var lancamentos = await _lancamentoRepository.ObterTodosAsync();
            return _mapper.Map<ICollection<LancamentoDto>>(lancamentos);
        }

        public async Task<ICollection<LancamentoDto>> ObterTodos(Guid usuarioId)
        {
            var lancamentos = await _lancamentoRepository.ObterTodosAsync(usuarioId);
            return _mapper.Map<ICollection<LancamentoDto>>(lancamentos);
        }

        public async Task Remover(Guid id)
        {
            var lancamento = await _lancamentoRepository.ObterPorId(id);
            if (lancamento is null)
            {
                throw new ApplicationException("Lançamento informado inválido");
            }

            await _lancamentoRepository.Remover(lancamento);
            await _lancamentoRepository.UnityOfWork.CommitAsync();
        }
    }
}
