using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Exceptions;

namespace FitFad.Domain.Entities.Person
{
    public class Client : Person<Client>
    {
        public List<Membership> Memberships { get; private set; } = [];
        public readonly FinancialAccount FinancialAccount;

        public Client()
        {
            FinancialAccount = new(this);
        }

        public DateTime GetEarliestMembershipStart()
        {
            if (Memberships.Count == 0)
            {
                throw new NoValidMembershipFound(this);
            }
            return Memberships
            .Select(membership => membership.StartTime)
            .Min(time => time);
        }

        internal void AddMembership(Membership membership)
        {
            Memberships.Add(membership);
        }

        internal bool RemoveMembership(Membership membership)
        {
            return Memberships.Remove(membership);
        }

        internal override void RegisterToClass(Class @class)
        {
            if (GetEarliestMembershipStart() >= @class.StartTime)
            {
                throw new NoValidMembershipFound(this);
            }
            Classes.Add(@class);
        }
    }
}
