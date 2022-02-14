using AutoFixture;
using Financa.Api.AppServices;
using Xunit;

namespace Financa.Api.Unit.Test
{
    public class AuthAppServiceTest
    {
        [Fact]
        public void RegistrarUsuario_Deve_Retornar_Sem_Senha()
        {
            var appService = new Fixture().Create<AuthAppService>();
        }
    }
}