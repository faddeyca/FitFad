using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace FitFad.Domain.Values
{
    [Owned]
    public abstract class AbstractValue<T> : IEquatable<T>
        where T : AbstractValue<T>
    {
        protected T CopyAndSet(Action<T> setProperty)
        {
            var copy = Copy();
            setProperty(copy);
            return copy;
        }

        private T Copy()
        {
            var config =
                new MapperConfiguration(cfg => cfg.CreateMap<T, T>());
            var mapper = config.CreateMapper();
            return mapper.Map<T>(this);
        }

        public bool Equals(T? other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this is null || other is null)
            {
                return false;
            }

            return GetType()
                .GetProperties()
                .Where(property => property.CanRead)
                .All(property =>
                {
                    var thisValue = property.GetValue(this);
                    var otherValue = property.GetValue(other);

                    if (ReferenceEquals(thisValue, otherValue))
                    {
                        return true;
                    }

                    if (thisValue is null || otherValue is null)
                    {
                        return false;
                    }

                    return thisValue.Equals(otherValue);
                });
        }

        public override bool Equals(object? obj)
        {
            return obj is T other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();

            hash.Add(GetType()
                .GetProperties()
                .Where(p => p.CanRead)
                .Select(p => p.GetValue(this)));

            return hash.ToHashCode();
        }

        public static bool operator ==(AbstractValue<T>? a, AbstractValue<T>? b) => a?.Equals(b) ?? b is null;

        public static bool operator !=(AbstractValue<T>? a, AbstractValue<T>? b) => !(a == b);
    }
}
