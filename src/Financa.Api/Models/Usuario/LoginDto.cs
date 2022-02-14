using System.ComponentModel.DataAnnotations;

namespace Financa.Api.Models.Usuario
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
    }
}
