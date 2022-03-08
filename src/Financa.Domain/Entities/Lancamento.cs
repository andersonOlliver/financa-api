
namespace Financa.Domain.Entities
{

    public partial class Lancamento : Entity
    {
        public decimal Valor { get; private set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        //public IReadOnlyCollection<ItemLancamento> Itens { get; private set; }

        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Guid UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public Guid? CartaoId { get; set; }
        public virtual Cartao? Cartao { get; private set; }

        private readonly List<ItemLancamento> _lancamentoItens;


        public IReadOnlyCollection<ItemLancamento> Itens => _lancamentoItens;

        protected Lancamento(): base(Guid.NewGuid())
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

        public void AdicionaCartao(Cartao cartao)
        {
            Cartao = cartao;
            CartaoId = cartao.Id;
        }

        public void AdicionaItem(ItemLancamento item)
        {
            _lancamentoItens.Add(item);
        }

        public void AdicionaParcelas(int quantidade = 1)
        {
            Enumerable.Range(1, quantidade).ToList().ForEach(parcela =>
            {
                var item = new ItemLancamento
                {
                    Parcela = parcela,
                    Valor = Valor / quantidade,
                    DataLancamento = Cartao!.CalculaFechamento(parcela)
                };
                AdicionaItem(item);
            });
        }
    }
}
