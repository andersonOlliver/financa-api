using System.ComponentModel.DataAnnotations;

namespace Financa.Api.Models
{
    public class CategoriaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage ="O campo {0} deve conter entre {2} e {1} caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cor { get; set; }
    }

    public class AdicionaCategoriaDto
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 10, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres")]
        public string Cor { get; set; }
    }

    public class DetalhaCategoriaDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Cor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
