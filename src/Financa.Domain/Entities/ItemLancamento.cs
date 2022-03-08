
namespace Financa.Domain.Entities
{
    public class ItemLancamento : Entity
    {
        public int Parcela { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataLancamento { get; private set; }
        public Guid LancamentoId { get; private set; }
        public virtual Lancamento Lancamento { get; private set; }

        protected ItemLancamento() : base()
        { }

        public ItemLancamento(int parcela, decimal valor, DateTime dataLancamento): base()
        {
            Parcela = parcela;
            Valor = valor;
            DataLancamento = dataLancamento;
        }
    }
}
