using System.ComponentModel.DataAnnotations;

namespace Common.Core.Model
{
    public abstract class Entity<T>
    {
        [Key]
        public T Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id.GetHashCode()).GetHashCode();
        }
    }
}
