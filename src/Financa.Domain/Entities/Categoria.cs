namespace Financa.Domain.Entities
{
    public class Categoria : Entity
    {
        public string Titulo { get; set; }
        public string Cor { get; set; }

        public Categoria()
        {

        }

        public Categoria(string titulo, string cor) : base()
        {
            Titulo = titulo;
            Cor = cor;
        }

        public Categoria(Guid id, string titulo, string cor) : base(id)
        {
            Titulo = titulo;
            Cor = cor;
            DataCadastro = DateTime.UtcNow;
        }

        // EF Rel.
        public ICollection<Lancamento> Lancamentos { get; set; }

        public static class CategoriaFactory
        {
            public static ICollection<Categoria> CategoriasIniciais()
            {
                return new[] {
                    new Categoria(Guid.Parse("9aa7181d-19aa-495e-8bc3-135bdef943cd"), "Estudo", "FFFDD835"),
                    new Categoria(Guid.Parse("af61a1b9-18fb-4331-9a51-2831bf068855"), "Transporte", "FF1565C0"),
                    new Categoria(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Alimentação", "FFF9A825"),
                    new Categoria(Guid.Parse("0bc1bb9a-5955-46f3-b495-b3664098dadc"), "Salario", "FF66BB6A"),
                    new Categoria(Guid.Parse("b5e595d0-3221-461f-8f37-ed79d714738f"), "Mercado", "FF1565C0"),
                    new Categoria(Guid.Parse("840eaac1-ee3e-41de-a8e6-f7e584a92b25"), "Pets", "FFEF5350"),
                    new Categoria(Guid.Parse("ca0a25b0-6c79-41bb-a415-fe149d5a24d4"), "Beleza", "FFFF8A80")
                };
            }
        }
    }
}
