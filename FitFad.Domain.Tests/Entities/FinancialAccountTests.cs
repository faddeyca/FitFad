using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Entities.Person;
using FitFad.Domain.Enums;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class FinancialAccountTests
    {
        private Client _client;
        private FinancialAccount _account;

        [SetUp]
        public void Setup()
        {
            _client = new Client();
            _account = new FinancialAccount(_client);
        }

        [Test]
        public void FinancialAccount_ShouldInitializeWithDefaultValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_account.Client, Is.EqualTo(_client));
                Assert.That(_account.Balance, Is.EqualTo(0));
                Assert.That(_account.AccountState, Is.EqualTo(AccountEntryType.Credit));
                Assert.That(_account.Transactions, Is.Empty);
            });
        }

        [Test]
        public void FinancialAccount_TopUp_ShouldIncreaseBalance()
        {
            _account.TopUp(100);

            Assert.Multiple(() =>
            {
                Assert.That(_account.Balance, Is.EqualTo(100));
                Assert.That(_account.AccountState, Is.EqualTo(AccountEntryType.Credit));
                Assert.That(_account.Transactions.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void FinancialAccount_TopUp_ShouldThrowExceptionForNonPositiveAmount()
        {
            Assert.Throws<ArgumentException>(() => _account.TopUp(0));
            Assert.Throws<ArgumentException>(() => _account.TopUp(-50));
        }

        [Test]
        public void FinancialAccount_Charge_ShouldDecreaseBalance()
        {
            _account.TopUp(100);
            _account.Charge(50);

            Assert.Multiple(() =>
            {
                Assert.That(_account.Balance, Is.EqualTo(50));
                Assert.That(_account.AccountState, Is.EqualTo(AccountEntryType.Credit));
                Assert.That(_account.Transactions.Count, Is.EqualTo(2));
            });
        }

        [Test]
        public void FinancialAccount_Charge_ShouldThrowExceptionForNonPositiveAmount()
        {
            Assert.Throws<ArgumentException>(() => _account.Charge(0));
            Assert.Throws<ArgumentException>(() => _account.Charge(-50));
        }

        [Test]
        public void FinancialAccount_Transactions_ShouldBeAddedCorrectly()
        {
            _account.TopUp(100);
            _account.Charge(50);

            Assert.That(_account.Transactions.Count, Is.EqualTo(2));
        }
    }
}
