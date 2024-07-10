using FitFad.Domain.Values;

namespace FitFad.Domain.Entities.Finances
{
    public class Transaction(
        FinancialAccount account,
        TransactionEntry transactionEntry,
        DateTime dateTime,
        string? notes = null) : AbstractValue<Transaction>
    {
        public readonly FinancialAccount Account = account;
        public readonly TransactionEntry TransactionEntry = transactionEntry;
        public readonly DateTime DateTime = dateTime;
        public string? Notes { get; private set; } = notes;

        public void EditNotes(string? notes) => Notes = notes;
    }
}
