namespace FitFad.Domain.Entities.Person
{
    public class Trainer : Person<Trainer>
    {
        public Trainer() { }

        internal override void RegisterToClass(Class @class)
        {
            Classes.Add(@class);
        }
    }
}
