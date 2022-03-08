namespace Financa.Domain.Dtos.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
