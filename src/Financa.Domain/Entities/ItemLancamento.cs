
namespace Financa.Domain.Entities
{
    public class ItemLancamento : Entity
    {
        public int Parcela { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public Guid LancamentoId { get; set; }
        public virtual Lancamento Lancamento { get; set; }

        public ItemLancamento() : base()
        { }
    }
}
