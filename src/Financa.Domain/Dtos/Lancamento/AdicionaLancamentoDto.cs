using Financa.Domain.Dtos.Cartao;
using Financa.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Financa.Domain.Dtos.Lancamento
{
    public class AdicionaLancamentoDto
    {
        [Range(double.NaN, double.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoLancamento TipoLancamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CategoriaDto Categoria { get; set; }
    }

    public class AdicionaDespesaDto
    {
        [Range(double.NaN, double.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public TipoPagamento TipoPagamento { get; set; }
        public int? QuantidadeParcelas { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CategoriaDto Categoria { get; set; }

        public DetalhaCartaoDto? Cartao { get; set; }

    }
}
