using FitFad.Domain.Enums;
using FitFad.Domain.Values;

namespace FitFad.Domain.Tests.Values
{
    [TestFixture]
    public class TransactionEntryTests
    {
        private TransactionEntry _creditEntry;
        private TransactionEntry _debitEntry;

        [SetUp]
        public void Setup()
        {
            _creditEntry = new TransactionEntry(-100m);
            _debitEntry = new TransactionEntry(150m);
        }

        [Test]
        public void TransactionEntry_ShouldInitializeCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry.TransactionType, Is.EqualTo(AccountEntryType.Credit));
                Assert.That(_creditEntry.Amount, Is.EqualTo(100m));

                Assert.That(_debitEntry.TransactionType, Is.EqualTo(AccountEntryType.Debit));
                Assert.That(_debitEntry.Amount, Is.EqualTo(150m));
            });
        }

        [Test]
        public void TransactionEntry_ShouldDetermineTransactionTypeCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry.TransactionType, Is.EqualTo(AccountEntryType.Credit));
                Assert.That(_debitEntry.TransactionType, Is.EqualTo(AccountEntryType.Debit));
            });
        }

        [Test]
        public void TransactionEntry_ShouldCalculateAmountCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry.Amount, Is.EqualTo(100m));
                Assert.That(_debitEntry.Amount, Is.EqualTo(150m));
            });
        }

        [Test]
        public void TransactionEntry_ShouldBeImmutable()
        {
            var modifiedEntry = _creditEntry.WithAmount(-200m);

            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry.Amount, Is.EqualTo(100m));
                Assert.That(modifiedEntry.Amount, Is.EqualTo(200m));
            });
        }

        [Test]
        public void TransactionEntry_WithAmount_ShouldReturnNewInstance()
        {
            var modifiedEntry = _creditEntry.WithAmount(-200m);

            Assert.Multiple(() =>
            {
                Assert.That(modifiedEntry.TransactionType, Is.EqualTo(AccountEntryType.Credit));
                Assert.That(modifiedEntry.Amount, Is.EqualTo(200m));
            });

            modifiedEntry = _debitEntry.WithAmount(50m);

            Assert.Multiple(() =>
            {
                Assert.That(modifiedEntry.TransactionType, Is.EqualTo(AccountEntryType.Debit));
                Assert.That(modifiedEntry.Amount, Is.EqualTo(50m));
            });
        }

        [Test]
        public void TransactionEntries_WithSameDetails_ShouldBeEqual()
        {
            var anotherCreditEntry = new TransactionEntry(-100m);
            var anotherDebitEntry = new TransactionEntry(150m);

            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry, Is.EqualTo(anotherCreditEntry));
                Assert.That(_debitEntry, Is.EqualTo(anotherDebitEntry));
            });
        }

        [Test]
        public void TransactionEntries_WithDifferentDetails_ShouldNotBeEqual()
        {
            var differentCreditEntry = new TransactionEntry(-200m);
            var differentDebitEntry = new TransactionEntry(100m);

            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry, Is.Not.EqualTo(differentCreditEntry));
                Assert.That(_debitEntry, Is.Not.EqualTo(differentDebitEntry));
            });
        }

        [Test]
        public void TransactionEntries_WithSameDetails_ShouldHaveSameHashCode()
        {
            var anotherCreditEntry = new TransactionEntry(-100m);
            var anotherDebitEntry = new TransactionEntry(150m);

            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry.GetHashCode(), Is.EqualTo(anotherCreditEntry.GetHashCode()));
                Assert.That(_debitEntry.GetHashCode(), Is.EqualTo(anotherDebitEntry.GetHashCode()));
            });
        }

        [Test]
        public void TransactionEntries_WithDifferentDetails_ShouldHaveDifferentHashCodes()
        {
            var differentCreditEntry = new TransactionEntry(-200m);
            var differentDebitEntry = new TransactionEntry(100m);

            Assert.Multiple(() =>
            {
                Assert.That(_creditEntry.GetHashCode(), Is.Not.EqualTo(differentCreditEntry.GetHashCode()));
                Assert.That(_debitEntry.GetHashCode(), Is.Not.EqualTo(differentDebitEntry.GetHashCode()));
            });
        }
    }
}
