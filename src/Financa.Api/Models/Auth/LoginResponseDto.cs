namespace Financa.Api.Models.Usuario
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
