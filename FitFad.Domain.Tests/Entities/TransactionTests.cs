using FitFad.Domain.Entities.Finances;
using FitFad.Domain.Entities.Person;
using FitFad.Domain.Values;

namespace FitFad.Domain.Tests.Entities
{
    [TestFixture]
    public class TransactionTests
    {
        private FinancialAccount _account;
        private TransactionEntry _transactionEntry;
        private Transaction _transaction;

        [SetUp]
        public void Setup()
        {
            _account = new FinancialAccount(new Client());
            _transactionEntry = new TransactionEntry(100);
            _transaction = new Transaction(_account, _transactionEntry, DateTime.Now, "Initial transaction");
        }

        [Test]
        public void Transaction_ShouldInitializeWithCorrectValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_transaction.Account, Is.EqualTo(_account));
                Assert.That(_transaction.TransactionEntry, Is.EqualTo(_transactionEntry));
                Assert.That(_transaction.DateTime, Is.LessThanOrEqualTo(DateTime.Now));
                Assert.That(_transaction.Notes, Is.EqualTo("Initial transaction"));
            });
        }

        [Test]
        public void Transaction_EditNotes_ShouldUpdateNotes()
        {
            _transaction.EditNotes("Updated transaction");

            Assert.That(_transaction.Notes, Is.EqualTo("Updated transaction"));
        }
    }
}
