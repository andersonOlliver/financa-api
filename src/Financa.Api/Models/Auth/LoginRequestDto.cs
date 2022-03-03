using System.ComponentModel.DataAnnotations;

namespace Financa.Api.Models.Usuario
{

    public class LoginRequestDto
    {
        [EmailAddress(ErrorMessage ="Email invalido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
