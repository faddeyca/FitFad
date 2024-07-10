using FitFad.Domain.Entities.Person;
using FitFad.Domain.Enums;
using FitFad.Domain.Exceptions;
using FitFad.Domain.Services;

namespace FitFad.Domain.Entities.Finances
{
    public class Membership : AbstractEntity<Membership>
    {
        public List<Client> Clients { get; private set; } = [];
        public readonly MembershipType MembershipType;

        public int MaxClients => MembershipTypeService.GetMaxClients(MembershipType);
        public decimal Price => MembershipTypeService.GetPrice(MembershipType);

        private DateTime _startTime;
        private DateTime _endTime;

        public Membership() { }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (value >= EndTime)
                {
                    throw new ArgumentException("Start time must be before end time.");
                }
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get => _endTime;
            set
            {
                if (value <= StartTime)
                {
                    throw new ArgumentException("Start time must be before end time.");
                }
                _endTime = value;
            }
        }

        public Client? PrimaryClient => Clients.FirstOrDefault();

        public Membership(MembershipType membershipType, DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
            {
                throw new ArgumentException("Start time must be before end time.");
            }
            MembershipType = membershipType;
            _startTime = startTime;
            _endTime = endTime;
        }

        public void AddClient(Client client)
        {
            if (Clients.Count >= MaxClients)
            {
                throw new MaximumNumberOfClientsReached(MaxClients);
            }
            Clients.Add(client);
            client.AddMembership(this);
        }

        public bool RemoveClient(Client client) => Clients.Remove(client) & client.RemoveMembership(this);
    }
}
