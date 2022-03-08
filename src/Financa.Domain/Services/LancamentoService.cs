using AutoMapper;
using Financa.Domain.Dtos.Lancamento;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;
using static Financa.Domain.Entities.Lancamento;

namespace Financa.Domain.Services
{
    public class LancamentoService : AbstractService<Lancamento, AdicionaLancamentoDto, LancamentoDto, DetalhaLancamentoDto>, ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository,
                                 IMapper mapper,
                                 ICartaoRepository cartaoRepository,
                                 IUsuarioRepository usuarioRepository) : base(mapper, lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _cartaoRepository = cartaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LancamentoDto> Adicionar(AdicionaLancamentoDto lancamentoDto, Guid? usuarioId)
        {
            Validar(usuarioId);
            var lancamento = _mapper.Map<Lancamento>(lancamentoDto);

            var usuario = await _usuarioRepository.ObterPorId(usuarioId!.Value);
            lancamento.AdicionaUsuario(usuario!);

            await _repository.Adicionar(lancamento);
            await _repository.UnityOfWork.CommitAsync();

            return _mapper.Map<LancamentoDto>(lancamento);
        }

        private Lancamento Transformar(AdicionaLancamentoDto lancamentoDto, Guid? usuarioId)
        {
            Lancamento lancamento = Transformar(lancamentoDto, usuarioId);
            return lancamento;
        }

        private static void Validar(Guid? usuarioId)
        {
            if (usuarioId is null) throw new ApplicationException("Deve informar um usuario");
        }

        public async Task<LancamentoDto> Adicionar(AdicionaDespesaDto lancamentoDto, Guid? usuarioId)
        {
            if (usuarioId is null) throw new ApplicationException("Deve informar um usuario");

            var lancamento = new LancamentoBuilder()
                .FromDto(lancamentoDto)
                .SetUsuario(await _usuarioRepository.ObterPorId(usuarioId!.Value, track: true))
                .SetCartao(await _cartaoRepository.ObterPorId(lancamentoDto.Cartao!.Id, track: true))
                .Build();

            if (lancamentoDto.TipoPagamento == TipoPagamento.Parcelado)
            {
                lancamento.AdicionaParcelas(lancamentoDto.QuantidadeParcelas ?? 1);
            }

            await _repository.Adicionar(lancamento);
            await _repository.UnityOfWork.CommitAsync();

            return _mapper.Map<LancamentoDto>(lancamento);
        }

        public async Task<ICollection<LancamentoDto>> ObterTodos(Guid usuarioId)
        {
            var lancamentos = await _lancamentoRepository.ObterTodosAsync(usuarioId);
            return _mapper.Map<ICollection<LancamentoDto>>(lancamentos);
        }
    }
}
