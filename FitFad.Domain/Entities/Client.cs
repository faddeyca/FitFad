using FitFad.Domain.Values;

namespace FitFad.Domain.Entities
{
    public class Client(Contact contact) : AbstractEntity<Client>
    {
        public Contact Contact { get; private set; } = contact;
        public List<Membership> Memberships { get; private set; } = [];
        public List<Class> Classes { get; private set; } = [];
    }
}
