using FitFad.Domain.Values;
using PhoneNumbers;

namespace FitFad.Domain.Tests
{
    [TestFixture]
    public class ContactTests
    {
        private Contact _contact1;
        private Contact _contact2;
        private Contact _contact3;
        private Contact _contact4;
        private Contact _nullContact1;
        private Contact _nullContact2;
        private Contact _mixedContact;
        private PhoneNumberUtil _phoneUtil;

        [SetUp]
        public void Setup()
        {
            _phoneUtil = PhoneNumberUtil.GetInstance();

            _contact1 = CreateContact(
                "Faddey", "Kryachko", ["Fyodor"],
                "faddey.kryachko@example.ru", "faddey.alt@example.ru", null,
                "+7-123-456-7890", null, null);

            _contact2 = CreateContact(
                "Faddey", "Kryachko", ["Fyodor"],
                "faddey.kryachko@example.ru", "faddey.alt@example.ru", null,
                "+7-123-456-7890", null, null);

            _contact3 = CreateContact(
                "Dmitry", "Ivanov", ["Dima"],
                "dmitry.ivanov@example.ru", null, "dima.alt@example.ru",
                "+7-654-321-0987", "+7-123-123-1234", null);

            _contact4 = CreateContact(
                "Alexei", "Smirnov", ["Alyosha"],
                "alexei.smirnov@example.ru", "alexei.alt@example.ru", "alexei2@example.ru",
                "+7-789-789-7890", "+7-987-987-9870", "+7-456-456-4560");

            _nullContact1 = CreateContact(null, null, null, null, null, null, null, null, null);
            _nullContact2 = CreateContact(null, null, null, null, null, null, null, null, null);
            _mixedContact = CreateContact(
                "Faddey", null, ["Fyodor"],
                "faddey.kryachko@example.ru", null, "faddey.alt@example.ru",
                "+7-123-456-7890", null, null);
        }

        private Contact CreateContact(
            string? firstName, string? lastName, List<string>? otherNames,
            string? email, string? email1, string? email2,
            string? phoneNumber, string? phoneNumber1, string? phoneNumber2)
        {
            return new Contact(
                firstName, lastName, otherNames,
                email, email1, email2,
                ParsePhoneNumber(phoneNumber),
                ParsePhoneNumber(phoneNumber1),
                ParsePhoneNumber(phoneNumber2));
        }

        private PhoneNumber? ParsePhoneNumber(string? phoneNumber)
        {
            return phoneNumber == null ? null : _phoneUtil.Parse(phoneNumber, "RU");
        }

        [Test]
        public void Contacts_WithSameDetails_ShouldBeEqual()
        {
            Assert.That(_contact1, Is.EqualTo(_contact2));
        }

        [Test]
        public void Contacts_WithDifferentDetails_ShouldNotBeEqual()
        {
            Assert.That(_contact1, Is.Not.EqualTo(_contact3));
        }

        [Test]
        public void Contacts_WithSameDetails_ShouldHaveSameHashCode()
        {
            Assert.That(_contact1.GetHashCode(), Is.EqualTo(_contact2.GetHashCode()));
        }

        [Test]
        public void Contacts_WithDifferentDetails_ShouldHaveDifferentHashCodes()
        {
            Assert.That(_contact1.GetHashCode(), Is.Not.EqualTo(_contact3.GetHashCode()));
        }

        [Test]
        public void Contacts_ShouldBeImmutable()
        {
            var modifiedContact = _contact1.WithFirstName("Dmitry");

            Assert.Multiple(() =>
            {
                Assert.That(_contact1, Is.EqualTo(_contact2));
                Assert.That(modifiedContact, Is.Not.EqualTo(_contact1));
            });
        }

        [Test]
        public void Contact_WithModifiedFirstName_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithFirstName("Dmitry");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.FirstName, Is.EqualTo("Dmitry"));
                Assert.That(modifiedContact.LastName, Is.EqualTo(_contact1.LastName));
            });
        }

        [Test]
        public void Contact_WithModifiedLastName_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithLastName("Ivanov");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.LastName, Is.EqualTo("Ivanov"));
                Assert.That(modifiedContact.FirstName, Is.EqualTo(_contact1.FirstName));
            });
        }

        [Test]
        public void Contact_WithModifiedOtherNames_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithOtherNames(["Fyodorovich"]);
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.OtherNames, Is.EqualTo(new List<string> { "Fyodorovich" }));
                Assert.That(modifiedContact.FirstName, Is.EqualTo(_contact1.FirstName));
            });
        }

        [Test]
        public void Contact_WithModifiedEmail_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithEmail("new.email@example.ru");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.Email, Is.EqualTo("new.email@example.ru"));
                Assert.That(modifiedContact.Email1, Is.EqualTo(_contact1.Email1));
            });
        }

        [Test]
        public void Contact_WithModifiedEmail1_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithEmail1("new.email1@example.ru");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.Email1, Is.EqualTo("new.email1@example.ru"));
                Assert.That(modifiedContact.Email, Is.EqualTo(_contact1.Email));
            });
        }

        [Test]
        public void Contact_WithModifiedEmail2_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithEmail2("new.email2@example.ru");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.Email2, Is.EqualTo("new.email2@example.ru"));
                Assert.That(modifiedContact.Email, Is.EqualTo(_contact1.Email));
            });
        }

        [Test]
        public void Contact_WithModifiedPhoneNumber_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithPhoneNumber(ParsePhoneNumber("+7-999-999-9999"));
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.PhoneNumber, Is.EqualTo(ParsePhoneNumber("+7-999-999-9999")));
                Assert.That(modifiedContact.PhoneNumber1, Is.EqualTo(_contact1.PhoneNumber1));
            });
        }

        [Test]
        public void Contact_WithModifiedPhoneNumber1_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithPhoneNumber1(ParsePhoneNumber("+7-888-888-8888"));
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.PhoneNumber1, Is.EqualTo(ParsePhoneNumber("+7-888-888-8888")));
                Assert.That(modifiedContact.PhoneNumber, Is.EqualTo(_contact1.PhoneNumber));
            });
        }

        [Test]
        public void Contact_WithModifiedPhoneNumber2_ShouldReturnNewInstance()
        {
            var modifiedContact = _contact1.WithPhoneNumber2(ParsePhoneNumber("+7-777-777-7777"));
            Assert.Multiple(() =>
            {
                Assert.That(modifiedContact.PhoneNumber2, Is.EqualTo(ParsePhoneNumber("+7-777-777-7777")));
                Assert.That(modifiedContact.PhoneNumber, Is.EqualTo(_contact1.PhoneNumber));
            });
        }

        [Test]
        public void Contacts_UsingEqualityOperator_ShouldBeEqual()
        {
            Assert.That(_contact1 == _contact2);
        }

        [Test]
        public void Contacts_UsingInequalityOperator_ShouldNotBeEqual()
        {
            Assert.That(_contact1 != _contact3);
        }

        [Test]
        public void Contact_WithAllNullFields_ShouldBehaveCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_nullContact1.FirstName, Is.Null);
                Assert.That(_nullContact1.LastName, Is.Null);
                Assert.That(_nullContact1.OtherNames, Is.Null);
                Assert.That(_nullContact1.Email, Is.Null);
                Assert.That(_nullContact1.Email1, Is.Null);
                Assert.That(_nullContact1.Email2, Is.Null);
                Assert.That(_nullContact1.PhoneNumber, Is.Null);
                Assert.That(_nullContact1.PhoneNumber1, Is.Null);
                Assert.That(_nullContact1.PhoneNumber2, Is.Null);
            });
        }

        [Test]
        public void Contact_WithNullFields_ShouldBeEqualToAnotherWithSameNullFields()
        {
            Assert.That(_nullContact1, Is.EqualTo(_nullContact2));
        }

        [Test]
        public void Contact_WithNullFields_ShouldNotBeEqualToNonNullContact()
        {
            Assert.That(_nullContact1, Is.Not.EqualTo(_contact1));
        }

        [Test]
        public void Contact_WithAllFieldsPopulated_ShouldBeEqualToAnotherWithSameFields()
        {
            var anotherContact = CreateContact(
                "Alexei", "Smirnov", ["Alyosha"],
                "alexei.smirnov@example.ru", "alexei.alt@example.ru", "alexei2@example.ru",
                "+7-789-789-7890", "+7-987-987-9870", "+7-456-456-4560");
            Assert.That(_contact4, Is.EqualTo(anotherContact));
        }

        [Test]
        public void Contact_WithMixedNullAndNonNullFields_ShouldBehaveCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_mixedContact.FirstName, Is.EqualTo("Faddey"));
                Assert.That(_mixedContact.LastName, Is.Null);
                Assert.That(_mixedContact.OtherNames, Is.EqualTo(new List<string> { "Fyodor" }));
                Assert.That(_mixedContact.Email, Is.EqualTo("faddey.kryachko@example.ru"));
                Assert.That(_mixedContact.Email1, Is.Null);
                Assert.That(_mixedContact.Email2, Is.EqualTo("faddey.alt@example.ru"));
                Assert.That(_mixedContact.PhoneNumber, Is.EqualTo(ParsePhoneNumber("+7-123-456-7890")));
            });
        }

        [Test]
        public void Contact_WithAllNullFields_ShouldHaveCorrectHashCode()
        {
            Assert.That(_nullContact1.GetHashCode(), Is.EqualTo(0));
        }
    }
}
