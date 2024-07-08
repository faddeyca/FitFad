using FitFad.Domain.Enums;

namespace FitFad.Domain.Entities
{
    public class Membership() : AbstractEntity<Membership>
    {
        public Client? PrimaryClient { get; private set; }
        public List<Client> Clients { get; private set; } = [];
        public MembershipType? MembershipType { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
    }
}
