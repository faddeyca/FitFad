using FitFad.Domain.Entities;
using FitFad.Domain.Entities.Person;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class TrainerTests
    {
        private Trainer _trainer;
        private Class _class;

        [SetUp]
        public void Setup()
        {
            _trainer = new Trainer();
            _class = new Class("Yoga Class", DateTime.Now, DateTime.Now.AddHours(1));
        }

        [Test]
        public void Trainer_ShouldInitializeWithDefaultValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_trainer.Contact, Is.Not.Null);
                Assert.That(_trainer.Address, Is.Not.Null);
                Assert.That(_trainer.Classes, Is.Empty);
            });
        }

        [Test]
        public void Trainer_RegisterToClass_ShouldAddClass()
        {
            _class.RegisterTrainer(_trainer);

            Assert.That(_trainer.Classes, Contains.Item(_class));
        }
    }
}
