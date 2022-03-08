namespace Financa.Domain.Dtos.Usuario
{
    public class DetalhaUsuarioDto : UsuarioDto
    {
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
