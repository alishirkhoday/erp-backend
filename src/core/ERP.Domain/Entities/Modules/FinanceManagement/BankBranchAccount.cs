namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class BankBranchAccount : BaseEntity
    {
        public BankBranch BankBranch { get; private set; } = default!;
        public string AccountNumber { get; private set; } = default!;
        public string CardNumber { get; private set; } = default!;
        public string InternationalBankAccountNumber { get; private set; } = default!;

        private BankBranchAccount()
        {
        }

        public BankBranchAccount(BankBranch bankBranch, string accountNumber, string cardNumber, string internationalBankAccountNumber)
        {
            ArgumentNullException.ThrowIfNull(bankBranch, nameof(bankBranch));
            ArgumentException.ThrowIfNullOrEmpty(accountNumber, nameof(accountNumber));
            ArgumentException.ThrowIfNullOrEmpty(cardNumber, nameof(cardNumber));
            ArgumentException.ThrowIfNullOrEmpty(internationalBankAccountNumber, nameof(internationalBankAccountNumber));
            BankBranch = bankBranch;
            AccountNumber = accountNumber;
            CardNumber = cardNumber;
            InternationalBankAccountNumber = internationalBankAccountNumber;
        }

        public void Update(string accountNumber, string cardNumber, string internationalBankAccountNumber)
        {
            ArgumentException.ThrowIfNullOrEmpty(accountNumber, nameof(accountNumber));
            ArgumentException.ThrowIfNullOrEmpty(cardNumber, nameof(cardNumber));
            ArgumentException.ThrowIfNullOrEmpty(internationalBankAccountNumber, nameof(internationalBankAccountNumber));
            AccountNumber = accountNumber;
            CardNumber = cardNumber;
            InternationalBankAccountNumber = internationalBankAccountNumber;
        }
    }
}
