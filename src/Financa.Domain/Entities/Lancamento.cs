
using Financa.CrossCuting.Validators;

namespace Financa.Domain.Entities
{

    public partial class Lancamento : Entity
    {
        public decimal Valor { get; private set; }
        public string Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public TipoLancamento TipoLancamento { get; private set; }
        public TipoPagamento TipoPagamento { get; private set; }

        public Guid CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }

        public Guid UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public Guid? CartaoId { get; private set; }
        public virtual Cartao? Cartao { get; private set; }

        private readonly List<ItemLancamento> _lancamentoItens;
        public IReadOnlyCollection<ItemLancamento> Itens => _lancamentoItens;

        protected Lancamento() : base(Guid.NewGuid())
        {
            _lancamentoItens = new List<ItemLancamento>();
        }

        public Lancamento(decimal valor, string titulo, string? descricao, TipoLancamento tipoLancamento, Guid categoriaId, Guid? cartaoId)
            : base(Guid.NewGuid())
        {

            Valor = valor;
            Titulo = titulo;
            Descricao = descricao;
            TipoLancamento = tipoLancamento;
            CategoriaId = categoriaId;
            CartaoId = cartaoId;
            _lancamentoItens = new List<ItemLancamento>();
        }

        public void AdicionaUsuario(Usuario usuario)
        {
            Usuario = usuario;
            UsuarioId = usuario.Id;
        }

        public void AdicionaCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AdicionaCartao(Cartao? cartao)
        {
            Cartao = cartao;
            CartaoId = cartao?.Id;
        }

        public void AdicionaItem(ItemLancamento item)
        {
            _lancamentoItens.Add(item);
        }

        public void AdicionaParcelas(int? quantidade)
        {
            switch (TipoPagamento)
            {
                case TipoPagamento.CreditoVista:
                    AdicionaCreditoVista();
                    break;
                case TipoPagamento.CreditoParcelado:
                    AdicionaCreditoVistaParcelado(quantidade ?? 1);
                    break;
            }
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Titulo, $"O campo {nameof(Titulo)} do {nameof(Lancamento).ToLower()} não pode estar vazio");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, $"O campo Categoria do {nameof(Lancamento).ToLower()} deve ser informado");
            Validacoes.ValidarSeIgual(UsuarioId, Guid.Empty, $"O campo Usuario do {nameof(Lancamento).ToLower()} deve ser informado");
            Validacoes.ValidarSeMenorQue(Valor, 1, $"O campo {nameof(Valor)} do {nameof(Lancamento).ToLower()} não pode ser menor ou igual a zero");
            Validacoes.ValidarSeNulo(TipoLancamento, $"O campo {nameof(TipoLancamento)} do {nameof(Lancamento).ToLower()} deve ser informado");
        }

        private void AdicionaCreditoVista()
            => AdicionaItem(new ItemLancamento(1, Valor, Cartao!.CalculaFechamento(1)));

        private void AdicionaCreditoVistaParcelado(int quantidade = 1)
            => Enumerable.Range(1, Math.Max(quantidade, 1))
                      .ToList()
                      .ForEach(parcela 
                        => AdicionaItem(new ItemLancamento(parcela: parcela,
                                                           valor: Valor / quantidade,
                                                           dataLancamento: Cartao!.CalculaFechamento(parcela)))
                      );

    }
}
