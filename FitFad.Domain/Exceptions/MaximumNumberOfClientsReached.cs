namespace FitFad.Domain.Exceptions
{
    public class MaximumNumberOfClientsReached : Exception
    {
        public MaximumNumberOfClientsReached()
            : base("The maximum number of clients has been reached.")
        {
        }

        public MaximumNumberOfClientsReached(int maximumNumberOfClients)
            : base($"The maximum number of clients ({maximumNumberOfClients}) has been reached.")
        {
        }
    }
}
