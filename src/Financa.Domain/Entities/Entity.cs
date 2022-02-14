namespace Financa.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public void NovaDataAtualizacao()
        {
            DataAtualizacao = DateTime.UtcNow;
        }

        public void NovaDataCadastro()
        {
            DataCadastro = DateTime.UtcNow;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {

            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return true;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
