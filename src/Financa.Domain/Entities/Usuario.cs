using BCryptNet = BCrypt.Net.BCrypt;

namespace Financa.Domain.Entities
{
    public class Usuario : Entity
    {

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        // Ef. Rel
        public ICollection<Lancamento> Lancamentos { get; set; }

        // Ef. Rel
        public ICollection<Cartao> Cartoes { get; set; }


        protected Usuario() { }

        public Usuario(Guid id) : base(id) { }

        public Usuario(string nome, string email, string senha) : base(Guid.NewGuid())
        {
            Nome = nome;
            Email = email;
            DataCadastro = DateTime.UtcNow;
            Senha = BCryptNet.HashPassword(senha);
            //AplicarSenha(senha);
        }

        public Usuario(Guid id, string nome, string email, string senha) : base(id)
        {
            Nome = nome;
            Email = email;
            DataCadastro = DateTime.UtcNow;
            DataAtualizacao = DateTime.UtcNow;
            AplicarSenha(senha);
        }


        public void AplicarSenha(string senha)
        {
            Senha = BCryptNet.HashPassword(senha);
        }

        public bool VerificaSenha(string senha)
        {
            return BCryptNet.Verify(senha, Senha);
        }

        public static class UsuarioFactory
        {
            public static Usuario UsuarioInicial()
            {
                return new Usuario(Guid.Parse("b5076faa-c390-450f-9c6a-e161610b03e7"))
                {
                    Nome = "Anderson Olliver",
                    Email = "anderson.olliver@gmail.com",
                    Senha = BCryptNet.HashPassword("12345678")
                };
            }
        }
    }
}
