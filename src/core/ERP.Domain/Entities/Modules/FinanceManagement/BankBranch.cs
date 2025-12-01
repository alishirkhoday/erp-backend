namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class BankBranch : BaseEntity
    {
        public Bank Bank { get; private set; } = default!;
        public string Name { get; private set; } = default!;

        private readonly List<BankBranchAccount> _accounts = [];
        public IReadOnlyList<BankBranchAccount> Accounts => _accounts;

        private BankBranch()
        {
        }

        public BankBranch(Bank bank, string name)
        {
            ArgumentNullException.ThrowIfNull(bank, nameof(bank));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Bank = bank;
            Name = name;
        }

        public void Update(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void AddAccount(BankBranchAccount account) => _accounts.Add(account);
    }
}
