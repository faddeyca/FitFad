using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Entities.Person;
using FitFad.Domain.Enums;
using FitFad.Domain.Exceptions;
using FitFad.Domain.Services;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class MembershipTests
    {
        private Membership _membershipSingle;
        private Membership _membershipMultiple;
        private Client _client;

        [SetUp]
        public void Setup()
        {
            _membershipSingle = new Membership(MembershipType.Adult, DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1));
            _membershipMultiple = new Membership(MembershipType.Family, DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1));
            _client = new Client();
        }

        [Test]
        public void Membership_ShouldInitializeWithCorrectValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_membershipSingle.MembershipType, Is.EqualTo(MembershipType.Adult));
                Assert.That(_membershipSingle.StartTime, Is.LessThan(_membershipSingle.EndTime));
                Assert.That(_membershipSingle.MaxClients, Is.GreaterThan(0));
                Assert.That(_membershipSingle.Price, Is.GreaterThan(0));
                Assert.That(_membershipSingle.Clients, Is.Empty);
            });
        }

        [Test]
        public void Membership_AddClient_ShouldAddClient()
        {
            _membershipSingle.AddClient(_client);

            Assert.That(_membershipSingle.Clients, Contains.Item(_client));
        }

        [Test]
        public void Membership_RemoveClient_ShouldRemoveClient()
        {
            _membershipSingle.AddClient(_client);
            var result = _membershipSingle.RemoveClient(_client);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(_membershipSingle.Clients, Does.Not.Contain(_client));
            });
        }

        [Test]
        public void Membership_AddClient_ShouldThrowExceptionIfMaxClientsReached()
        {
            for (int i = 0; i < MembershipTypeService.GetMaxClients(_membershipSingle.MembershipType); i++)
            {
                _membershipSingle.AddClient(new Client());
            }

            Assert.Throws<MaximumNumberOfClientsReached>(() => _membershipSingle.AddClient(new Client()));
        }

        [Test]
        public void Membership_PrimaryClient_ShouldReturnFirstClient()
        {
            _membershipMultiple.AddClient(_client);
            var client2 = new Client();
            _membershipMultiple.AddClient(client2);

            Assert.That(_membershipMultiple.PrimaryClient, Is.EqualTo(_client));
        }
    }
}
