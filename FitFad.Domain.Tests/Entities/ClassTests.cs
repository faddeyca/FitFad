using FitFad.Domain.Entities;
using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Entities.Person;
using FitFad.Domain.Enums;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class ClassTests
    {
        private Class _class;
        private Trainer _trainer;
        private Client _client;
        private Membership _membership;

        [SetUp]
        public void Setup()
        {
            _class = new Class("Yoga Class", DateTime.Now, DateTime.Now.AddHours(1.5));
            _trainer = new Trainer();
            _client = new Client();
            _membership = new Membership(MembershipType.Adult, DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(2));
            _membership.AddClient(_client);
        }

        [Test]
        public void Class_ShouldInitializeWithCorrectValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_class.Name, Is.EqualTo("Yoga Class"));
                Assert.That(_class.StartTime, Is.LessThan(_class.EndTime));
                Assert.That(_class.Duration, Is.EqualTo(_class.EndTime - _class.StartTime));
                Assert.That(_class.Trainer, Is.Empty);
                Assert.That(_class.Clients, Is.Empty);
            });
        }

        [Test]
        public void Class_RegisterTrainer_ShouldAddTrainer()
        {
            _class.RegisterTrainer(_trainer);

            Assert.That(_class.Trainer, Contains.Item(_trainer));
        }

        [Test]
        public void Class_RemoveTrainer_ShouldRemoveTrainer()
        {
            _class.RegisterTrainer(_trainer);
            var result = _class.RemoveTrainer(_trainer);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(_class.Trainer, Does.Not.Contain(_trainer));
            });
        }

        [Test]
        public void Class_RegisterClient_ShouldAddClient()
        {
            _class.RegisterClient(_client);

            Assert.That(_class.Clients, Contains.Item(_client));
        }

        [Test]
        public void Class_RemoveClient_ShouldRemoveClient()
        {
            _class.RegisterClient(_client);
            var result = _class.RemoveClient(_client);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(_class.Clients, Does.Not.Contain(_client));
            });
        }
    }
}
