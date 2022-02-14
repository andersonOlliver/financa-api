
namespace Financa.Domain.Entities
{

    public class Lancamento : Entity
    {
        public decimal Valor { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
