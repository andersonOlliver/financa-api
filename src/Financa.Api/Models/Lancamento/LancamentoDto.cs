namespace Financa.Api.Models.Lancamento
{
    public class LancamentoDto : AdicionaLancamentoDto
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
