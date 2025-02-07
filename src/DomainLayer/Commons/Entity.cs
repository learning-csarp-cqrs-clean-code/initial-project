namespace DomainLayer.Commons
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid id) => Id = id;
        public Guid Id { get; protected init; }

        public static bool operator==(Entity? first, Entity? second) => first is not null && second is not null && first.Equals (second);

        public static bool operator !=(Entity? first, Entity? second) => !(first == second);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Entity other || GetType() != obj.GetType()) return false;
            return Id == other.Id;
        }

        public bool Equals(Entity? other) =>other is not null && GetType() == other.GetType() && Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
