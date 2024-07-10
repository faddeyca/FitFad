using FitFad.Domain.Values;

namespace FitFad.Domain.Tests.Values
{
    [TestFixture]
    public class AddressTests
    {
        private Address _address1;
        private Address _address2;
        private Address _address3;
        private Address _address4;

        [SetUp]
        public void Setup()
        {
            _address1 = new Address("1", "Test Street", "Auckland", "Auckland Central", "1010", "New Zealand");
            _address2 = new Address("1", "Test Street", "Auckland", "Auckland Central", "1010", "New Zealand");
            _address3 = new Address("2", "Test Avenue", "Wellington", "Te Aro", "6011", "New Zealand");
            _address4 = new Address("3/130", "Ponsonby Road", "Auckland", "Grey Lynn", "1011", "New Zealand");
        }

        [Test]
        public void Addresses_WithSameDetails_ShouldBeEqual()
        {
            Assert.That(_address1, Is.EqualTo(_address2));
        }

        [Test]
        public void Addresses_WithDifferentDetails_ShouldNotBeEqual()
        {
            Assert.That(_address1, Is.Not.EqualTo(_address3));
        }

        [Test]
        public void Addresses_WithSameDetails_ShouldHaveSameHashCode()
        {
            Assert.That(_address1.GetHashCode(), Is.EqualTo(_address2.GetHashCode()));
        }

        [Test]
        public void Addresses_WithDifferentDetails_ShouldHaveDifferentHashCodes()
        {
            Assert.That(_address1.GetHashCode(), Is.Not.EqualTo(_address3.GetHashCode()));
        }

        [Test]
        public void Addresses_ShouldBeImmutable()
        {
            var modifiedAddress = _address1.WithStreetNumber("2");

            Assert.Multiple(() =>
            {
                Assert.That(_address1, Is.EqualTo(_address2));
                Assert.That(modifiedAddress, Is.Not.EqualTo(_address1));
            });
        }

        [Test]
        public void Address_WithModifiedStreetNumber_ShouldReturnNewInstance()
        {
            var modifiedAddress = _address1.WithStreetNumber("2");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedAddress.StreetNumber, Is.EqualTo("2"));
                Assert.That(modifiedAddress.StreetName, Is.EqualTo(_address1.StreetName));
            });
        }

        [Test]
        public void Address_WithModifiedStreetName_ShouldReturnNewInstance()
        {
            var modifiedAddress = _address1.WithStreetName("New Street");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedAddress.StreetName, Is.EqualTo("New Street"));
                Assert.That(modifiedAddress.StreetNumber, Is.EqualTo(_address1.StreetNumber));
            });
        }

        [Test]
        public void Address_WithModifiedCity_ShouldReturnNewInstance()
        {
            var modifiedAddress = _address1.WithCity("Hamilton");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedAddress.City, Is.EqualTo("Hamilton"));
                Assert.That(modifiedAddress.Suburb, Is.EqualTo(_address1.Suburb));
            });
        }

        [Test]
        public void Address_WithModifiedSuburb_ShouldReturnNewInstance()
        {
            var modifiedAddress = _address1.WithSuburb("Ponsonby");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedAddress.Suburb, Is.EqualTo("Ponsonby"));
                Assert.That(modifiedAddress.City, Is.EqualTo(_address1.City));
            });
        }

        [Test]
        public void Address_WithModifiedPostalCode_ShouldReturnNewInstance()
        {
            var modifiedAddress = _address1.WithPostalCode("1021");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedAddress.PostalCode, Is.EqualTo("1021"));
                Assert.That(modifiedAddress.Country, Is.EqualTo(_address1.Country));
            });
        }

        [Test]
        public void Address_WithModifiedCountry_ShouldReturnNewInstance()
        {
            var modifiedAddress = _address1.WithCountry("Australia");
            Assert.Multiple(() =>
            {
                Assert.That(modifiedAddress.Country, Is.EqualTo("Australia"));
                Assert.That(modifiedAddress.PostalCode, Is.EqualTo(_address1.PostalCode));
            });
        }

        [Test]
        public void Address_ToString_ShouldReturnFormattedString()
        {
            var expectedString = "1 Test Street, Auckland Central, Auckland, 1010, New Zealand";
            Assert.That(_address1.ToString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void Addresses_UsingEqualityOperator_ShouldBeEqual()
        {
            Assert.That(_address1 == _address2);
        }

        [Test]
        public void Addresses_UsingInequalityOperator_ShouldNotBeEqual()
        {
            Assert.That(_address1 != _address3);
        }

        [Test]
        public void Address_WithAllNullFields_ShouldBehaveCorrectly()
        {
            var nullAddress = new Address(null, null, null, null, null, null);
            Assert.Multiple(() =>
            {
                Assert.That(nullAddress.StreetNumber, Is.Null);
                Assert.That(nullAddress.StreetName, Is.Null);
                Assert.That(nullAddress.City, Is.Null);
                Assert.That(nullAddress.Suburb, Is.Null);
                Assert.That(nullAddress.PostalCode, Is.Null);
                Assert.That(nullAddress.Country, Is.Null);
            });
        }

        [Test]
        public void Address_WithNullFields_ShouldBeEqualToAnotherWithSameNullFields()
        {
            var nullAddress1 = new Address(null, null, null, null, null, null);
            var nullAddress2 = new Address(null, null, null, null, null, null);
            Assert.That(nullAddress1, Is.EqualTo(nullAddress2));
        }

        [Test]
        public void Address_WithNullFields_ShouldNotBeEqualToNonNullAddress()
        {
            var nullAddress = new Address(null, null, null, null, null, null);
            Assert.That(nullAddress, Is.Not.EqualTo(_address1));
        }

        [Test]
        public void Address_WithNullFields_ShouldReturnFormattedString()
        {
            var nullAddress = new Address(null, null, null, null, null, null);
            var expectedString = " , , , , ";
            Assert.That(nullAddress.ToString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void Address_WithMixedNullAndNonNullFields_ShouldBehaveCorrectly()
        {
            var mixedAddress = new Address(null, "Ponsonby Road", "Auckland", "Grey Lynn", "1011", null);
            var expectedString = " Ponsonby Road, Grey Lynn, Auckland, 1011, ";
            Assert.That(mixedAddress.ToString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void Address_WithMixedNullAndNonNullFields_ShouldBeEqualToAnotherWithSameFields()
        {
            var mixedAddress1 = new Address(null, "Ponsonby Road", "Auckland", "Grey Lynn", "1011", null);
            var mixedAddress2 = new Address(null, "Ponsonby Road", "Auckland", "Grey Lynn", "1011", null);
            Assert.That(mixedAddress1, Is.EqualTo(mixedAddress2));
        }

        [Test]
        public void Address_WithAllFieldsPopulated_ShouldBeEqualToAnotherWithSameFields()
        {
            var anotherAddress = new Address("3/130", "Ponsonby Road", "Auckland", "Grey Lynn", "1011", "New Zealand");
            Assert.That(_address4, Is.EqualTo(anotherAddress));
        }

        [Test]
        public void Address_WithAllFieldsPopulated_ShouldReturnFormattedString()
        {
            var expectedString = "3/130 Ponsonby Road, Grey Lynn, Auckland, 1011, New Zealand";
            Assert.That(_address4.ToString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void Address_WithNullAndNonNullMixedFields_ShouldReturnFormattedString()
        {
            var mixedAddress = new Address("3/130", null, "Auckland", "Grey Lynn", null, "New Zealand");
            var expectedString = "3/130 , Grey Lynn, Auckland, , New Zealand";
            Assert.That(mixedAddress.ToString(), Is.EqualTo(expectedString));
        }
    }
}
