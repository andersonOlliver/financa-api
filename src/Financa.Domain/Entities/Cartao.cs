
namespace Financa.Domain.Entities
{
    public class Cartao : Entity
    {
        public string Titulo { get; set; }
        public decimal Limite { get; set; }
        public int DiaVencimento { get; set; }
        public int DiaFechamento { get; set; }

        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        // EF Rel.
        public ICollection<Lancamento> Lancamentos { get; set; }

        public DateTime ProximoFechamento
        {
            get
            {
                var hoje = DateTime.UtcNow;
                if(hoje.Day < DiaFechamento)
                    return new DateTime(hoje.Year, hoje.Month, DiaFechamento);  

                return new DateTime(hoje.Year, hoje.Month, DiaFechamento).AddMonths(1);
            }
        }

        public DateTime CalculaFechamento(int mes)
        {
            return ProximoFechamento.AddMonths(mes);
           
            //var hoje = DateTime.UtcNow;
            //if (hoje.Day < DiaFechamento)
            //    return new DateTime(hoje.Year, hoje.Month, DiaFechamento);

            //return new DateTime(hoje.Year, hoje.Month, DiaFechamento).AddMonths(1);
        }
    }
}
