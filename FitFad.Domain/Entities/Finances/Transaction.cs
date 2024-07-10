using FitFad.Domain.Values;

namespace FitFad.Domain.Entities.Finances
{
    public class Transaction : AbstractEntity<Transaction>
    {
        public readonly FinancialAccount Account;
        public readonly TransactionEntry TransactionEntry;
        public readonly DateTime DateTime;
        public string? Notes { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Transaction() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Transaction(
            FinancialAccount account,
            TransactionEntry transactionEntry,
            DateTime dateTime,
            string? notes = null)
        {
            Account = account;
            TransactionEntry = transactionEntry;
            DateTime = dateTime;
            Notes = notes;
        }

        public void EditNotes(string? notes) => Notes = notes;
    }
}
