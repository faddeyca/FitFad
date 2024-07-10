using FitFad.Domain.Values;

namespace FitFad.Domain.Entities.Person
{
    public abstract class Person<T> : AbstractEntity<T>
        where T : Person<T>
    {
        public Contact Contact { get; private set; } = new Contact();
        public Address Address { get; private set; } = new Address();
        public List<Class> Classes { get; private set; } = [];

        public bool RemoveFromClass(Class @class)
        {
            return Classes.Remove(@class);
        }

        internal abstract void RegisterToClass(Class @class);

        public override string ToString() => Contact.FullName;
    }
}
