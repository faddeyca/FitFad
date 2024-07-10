using FitFad.Domain.Entities.Person;
using FitFad.Domain.Exceptions;

namespace FitFad.Domain.Tests.Exceptions
{
    [TestFixture]
    public class NoValidMembershipFoundTests
    {
        [Test]
        public void NoValidMembershipFound_DefaultConstructor_ShouldReturnCorrectMessage()
        {
            var exception = new NoValidMembershipFound();
            Assert.That(exception.Message, Is.EqualTo("No valid membership found."));
        }

        [Test]
        public void NoValidMembershipFound_ParameterizedConstructor_ShouldReturnCorrectMessage()
        {
            var client = new Client();
            var exception = new NoValidMembershipFound(client);
            Assert.That(exception.Message, Is.EqualTo($"No valid membership found for client {client}."));
        }
    }
}
