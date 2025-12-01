namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanBankAccount : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public string BankName { get; private set; } = default!;
        public string AccountNumber { get; private set; } = default!;
        public string CardNumber { get; private set; } = default!;
        public string InternationalBankAccountNumber { get; private set; } = default!;
        public bool IsDefault { get; private set; }

        private HumanBankAccount()
        {
        }

        public HumanBankAccount(Human human, string bankName, string accountNumber, string cardNumber, string internationalBankAccountNumber)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            ArgumentException.ThrowIfNullOrEmpty(bankName, nameof(bankName));
            ArgumentException.ThrowIfNullOrEmpty(accountNumber, nameof(accountNumber));
            ArgumentException.ThrowIfNullOrEmpty(cardNumber, nameof(cardNumber));
            Human = human;
            BankName = bankName;
            AccountNumber = accountNumber;
            CardNumber = cardNumber;
            InternationalBankAccountNumber = internationalBankAccountNumber;
        }

        public void Update(string bankName, string accountNumber, string cardNumber, string internationalBankAccountNumber)
        {

            ArgumentException.ThrowIfNullOrEmpty(bankName, nameof(bankName));
            ArgumentException.ThrowIfNullOrEmpty(accountNumber, nameof(accountNumber));
            ArgumentException.ThrowIfNullOrEmpty(cardNumber, nameof(cardNumber));
            ArgumentException.ThrowIfNullOrEmpty(internationalBankAccountNumber, nameof(internationalBankAccountNumber));
            BankName = bankName;
            AccountNumber = accountNumber;
            CardNumber = cardNumber;
            InternationalBankAccountNumber = internationalBankAccountNumber;
        }

        public void SetIsDefault() => IsDefault = true;
    }
}
