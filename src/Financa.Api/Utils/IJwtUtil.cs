using Financa.Domain.Entities;

namespace Financa.Api.Utils
{
    public interface IJwtUtil
    {
        (string, DateTime) GenerateToken(Usuario usuario);
        Guid? ValidateToken(string? token);
    }
}