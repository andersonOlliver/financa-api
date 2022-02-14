namespace Financa.Api.Models.Usuario
{
    public class DetalhaUsuarioDto : AdicionaUsuarioDto
    {
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
