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

                    if (thisValue is IEnumerable<object> sequence1
                        && otherValue is IEnumerable<object> sequence2)
                    {
                        return sequence1.SequenceEqual(sequence2);
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
            var properties = GetType()
                .GetProperties()
                .Where(p => p.CanRead)
                .OrderBy(p => p.Name)
                .Select(p => p.GetValue(this))
                .Where(value => value != null);

            var hash = 0;
            foreach (var property in properties)
            {
                if (property is null)
                {
                    continue;
                }
                if (property is IEnumerable<object> sequence && property is not string)
                {
                    var subHash = 0;
                    foreach (var element in sequence)
                    {
                        subHash = HashCode.Combine(subHash, element?.GetHashCode() ?? 0);
                    }
                }
                else
                {
                    hash = HashCode.Combine(hash, property.GetHashCode());
                }
            }

            return hash;
        }


        public static bool operator ==(AbstractValue<T>? a, AbstractValue<T>? b) => a?.Equals(b) ?? b is null;

        public static bool operator !=(AbstractValue<T>? a, AbstractValue<T>? b) => !(a == b);
    }
}
