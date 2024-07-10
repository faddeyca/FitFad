using FitFad.Domain.Entities.Person;
using FitFad.Domain.Enums;
using FitFad.Domain.Values;

namespace FitFad.Domain.Entities.Finances
{
    public class FinancialAccount : AbstractEntity<FinancialAccount>
    {
        public readonly Client Client;
        public readonly Guid ClientId;

        private decimal _rawBalance = 0;
        public List<Transaction> Transactions { get; private set; } = [];

        public AccountEntryType AccountState => _rawBalance <= 0 ? AccountEntryType.Credit : AccountEntryType.Debit;
        public decimal Balance => Math.Abs(_rawBalance);

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public FinancialAccount() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public FinancialAccount(Client client)
        {
            ClientId = client.Id;
            Client = client;
        }

        public void TopUp(decimal amount, DateTime? time = null, string? notes = "Top up account")
        {
            if (amount <= 0)
            {
                throw new ArgumentException("TopUp amount must be a positive number");
            }

            ProcessTransaction(-amount, time, notes);
        }

        public void Charge(decimal amount, DateTime? time = null, string? notes = "Charge account")
        {
            if (amount <= 0)
            {
                throw new ArgumentException("TopUp amount must be a positive number");
            }

            ProcessTransaction(amount, time, notes);
        }

        private void ProcessTransaction(decimal amount, DateTime? time, string? notes)
        {
            var transactionEntry = new TransactionEntry(amount);
            time ??= DateTime.Now;

            var transaction = new Transaction(this, transactionEntry, time.Value, notes);

            Transactions.Add(transaction);

            _rawBalance += amount;
        }
    }
}
