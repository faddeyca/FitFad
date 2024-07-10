using FitFad.Domain.Exceptions;

namespace FitFad.Domain.Tests.Exceptions
{
    [TestFixture]
    public class MaximumNumberOfClientsReachedTests
    {
        [Test]
        public void MaximumNumberOfClientsReached_DefaultConstructor_ShouldReturnCorrectMessage()
        {
            var exception = new MaximumNumberOfClientsReached();
            Assert.That(exception.Message, Is.EqualTo("The maximum number of clients has been reached."));
        }

        [Test]
        public void MaximumNumberOfClientsReached_ParameterizedConstructor_ShouldReturnCorrectMessage()
        {
            var exception = new MaximumNumberOfClientsReached(5);
            Assert.That(exception.Message, Is.EqualTo("The maximum number of clients (5) has been reached."));
        }
    }
}
