using FitFad.Domain.Entities;
using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Entities.Person;
using FitFad.Domain.Enums;
using FitFad.Domain.Exceptions;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class ClientTests
    {
        private Client _client;
        private Class _class;
        private Membership _membership;

        [SetUp]
        public void Setup()
        {
            _client = new Client();
            _class = new Class("Yoga Class", DateTime.Now, DateTime.Now.AddHours(1));
            _membership = new Membership(MembershipType.Adult, DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1));
            _membership.AddClient(_client);
        }

        [Test]
        public void Client_AddMembership_ShouldWorkCorrectly()
        {
            Assert.That(_client.Memberships, Contains.Item(_membership));
        }

        [Test]
        public void Client_RemoveMembership_ShouldWorkCorrectly()
        {
            _membership.RemoveClient(_client);

            Assert.That(_client.Memberships, Is.Empty);
        }

        [Test]
        public void Client_RegisterToClass_ShouldThrowExceptionIfNoValidMembership()
        {
            _membership.RemoveClient(_client);

            Assert.Throws<NoValidMembershipFound>(() => _class.RegisterClient(_client));
        }

        [Test]
        public void Client_RegisterToClass_ShouldAddClassIfValidMembership()
        {
            Assert.DoesNotThrow(() => _class.RegisterClient(_client));
            Assert.That(_client.Classes, Contains.Item(_class));
        }

        [Test]
        public void Client_EarliestMembershipStart_ShouldReturnCorrectValue()
        {
            var membership1 = new Membership(MembershipType.Adult, DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1));
            var membership2 = new Membership(MembershipType.Adult, DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(1));

            membership1.AddClient(_client);
            membership2.AddClient(_client);

            Assert.That(_client.GetEarliestMembershipStart, Is.EqualTo(membership2.StartTime));
        }
    }
}
