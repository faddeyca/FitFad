using FitFad.Domain.Enums;

namespace FitFad.Domain.Values
{
    public class TransactionEntry(
        decimal rawAmount = 0) : AbstractValue<TransactionEntry>
    {
        internal decimal RawAmount { get; private set; } = rawAmount;

        public AccountEntryType TransactionType => RawAmount <= 0 ? AccountEntryType.Credit : AccountEntryType.Debit;
        public decimal Amount => Math.Abs(RawAmount);


        public TransactionEntry WithAmount(decimal amount)
        {
            return CopyAndSet(copy => copy.RawAmount = amount);
        }
    }
}
