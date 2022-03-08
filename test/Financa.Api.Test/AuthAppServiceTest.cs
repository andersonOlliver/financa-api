using AutoFixture;
using Financa.Domain.Services;
using Xunit;

namespace Financa.Api.Unit.Test
{
    public class AuthAppServiceTest
    {
        [Fact]
        public void RegistrarUsuario_Deve_Retornar_Sem_Senha()
        {
            var appService = new Fixture().Create<AuthService>();
        }
    }
}