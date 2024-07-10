using FitFad.Domain.Entities;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Contact_ShouldInitializeWithDefaultValues()
        {
            var contact = new Contact();

            Assert.Multiple(() =>
            {
                Assert.That(contact.FirstName, Is.Null);
                Assert.That(contact.LastName, Is.Null);
                Assert.That(contact.OtherNames, Is.Null);
                Assert.That(contact.Email, Is.Null);
                Assert.That(contact.Email1, Is.Null);
                Assert.That(contact.Email2, Is.Null);
                Assert.That(contact.PhoneNumber, Is.Null);
                Assert.That(contact.PhoneNumber1, Is.Null);
                Assert.That(contact.PhoneNumber2, Is.Null);
            });
        }

        [Test]
        public void Contact_FullName_ShouldReturnCorrectValue()
        {
            var contact = new Contact("John", "Doe");

            Assert.That(contact.FullName, Is.EqualTo("John Doe"));
        }
    }
}
