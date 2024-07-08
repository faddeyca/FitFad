using FitFad.Domain.Values;

namespace FitFad.Domain.Entities
{
    public class Trainer(Contact contact) : AbstractEntity<Trainer>
    {
        public Contact Contact { get; private set; } = contact;
        public List<Class> Classes { get; private set; } = [];
    }
}
