using FitFad.Domain.Entities.Person;

namespace FitFad.Domain.Exceptions
{
    public class NoValidMembershipFound : Exception
    {
        public NoValidMembershipFound()
            : base("No valid membership found.")
        {
        }

        public NoValidMembershipFound(Client client)
            : base($"No valid membership found for client {client}.")
        {
        }
    }
}
