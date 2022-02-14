namespace Financa.Domain.Entities
{
    public class Categoria: Entity
    {
        public string Titulo { get; set; }
        public string Cor { get; set; }

        public Categoria()
        {

        }

        public Categoria(string titulo, string cor)
        {
            Titulo = titulo;
            Cor = cor;
        }

        // EF Rel.
        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}
