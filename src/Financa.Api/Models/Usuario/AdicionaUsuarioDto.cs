using System.ComponentModel.DataAnnotations;

namespace Financa.Api.Models.Usuario
{
    public class AdicionaUsuarioDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email invalido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Deve ser equivalente ao campo Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string RepitaSenha { get; set; }
    }
}
