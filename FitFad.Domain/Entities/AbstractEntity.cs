using System.ComponentModel.DataAnnotations;

namespace FitFad.Domain.Entities
{
    public abstract class AbstractEntity<T>
        where T : AbstractEntity<T>
    {
        [Key]
        public readonly Guid Id = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            if (obj is T entity && obj is not null)
            {
                return entity.Id == Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(AbstractEntity<T>? a, AbstractEntity<T>? b) => a?.Equals(b) ?? b is null;

        public static bool operator !=(AbstractEntity<T>? a, AbstractEntity<T>? b) => !(a == b);
    }
}
