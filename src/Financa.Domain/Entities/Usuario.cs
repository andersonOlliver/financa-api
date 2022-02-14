using BCryptNet = BCrypt.Net.BCrypt;

namespace Financa.Domain.Entities
{
    public class Usuario : Entity
    {
        private string senha;

        protected Usuario() { }

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

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha
        {
            get => senha; private set
            {
                senha = value;
            }
        }

        // Ef. Rel
        public ICollection<Lancamento> Lancamentos { get; set; }

        public void AplicarSenha(string senha)
        {
            Senha = BCryptNet.HashPassword(senha);
        }

        public bool VerificaSenha(string senha)
        {
            return BCryptNet.Verify(senha, Senha);
        }
    }
}
