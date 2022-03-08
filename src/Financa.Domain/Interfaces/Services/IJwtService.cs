using Financa.Domain.Entities;

namespace Financa.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        (string, DateTime) GenerateToken(Usuario usuario);
        Guid? ValidateToken(string? token);
    }
}