using Financa.Domain.Entities;
using Xunit;

namespace Financa.Domain.Unit.Test
{
    public class UsuarioTest
    {
        [Fact]
        public void Usuario_Senha_DeveSerEmbaralhada()
        {
            var senha = "12345678";
            var usuario = new Usuario("", "", senha);
            Assert.NotEmpty(usuario.Senha);
            Assert.NotEqual(senha, usuario.Senha);
        }
    }
}