namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class DocumentItem : BaseEntity
    {
        public Document Document { get; private set; } = default!;
        public Account Account { get; private set; } = default!;
        public short Priority { get; private set; }
        public decimal Debtor { get; private set; }
        public decimal Creditor { get; private set; }

        private DocumentItem()
        {
        }

        public DocumentItem(Document document, Account account, short priority, decimal debtor, decimal creditor)
        {
            ArgumentNullException.ThrowIfNull(document, nameof(document));
            ArgumentNullException.ThrowIfNull(account, nameof(account));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(debtor, nameof(debtor));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(creditor, nameof(creditor));
            if (debtor <= 0 && creditor <= 0 || debtor > 0 && creditor > 0)
                throw new ArgumentException("Either debtor or creditor must be set, but not both.");
            Document = document;
            Account = account;
            Priority = priority;
            Debtor = debtor;
            Creditor = creditor;
        }
    }
}
