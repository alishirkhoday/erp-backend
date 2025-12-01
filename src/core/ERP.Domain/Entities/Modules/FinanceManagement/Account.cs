namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class Account : BaseEntity
    {
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public AccountType Type { get; private set; }
        public AccountGroup Group { get; private set; }
        public AccountBalance Balance { get; private set; }
        public FinancialStatement FinancialStatement { get; private set; }
        public bool IsFinal { get; private set; }
        public decimal Inventory { get; private set; }
        public bool IsSystematic { get; private set; }
        public Guid? ParentId { get; private set; }
        public Account? Parent { get; private set; }

        private readonly List<Account> _children = [];
        public IReadOnlyList<Account> Children => _children;

        private Account()
        {
        }

        public Account(string code, string name, AccountType type, AccountGroup group, AccountBalance balance, FinancialStatement financialStatement, bool isFinal, Account? parent = null, bool isSystematic = false)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Code = code;
            Name = name;
            Type = type;
            Group = group;
            Balance = balance;
            FinancialStatement = financialStatement;
            IsFinal = isFinal;
            if (parent is not null)
            {
                Parent = parent;
                ParentId = parent.Id;
            }
            IsSystematic = isSystematic;
        }

        public void Update(string code, string name, AccountType type, AccountGroup group, AccountBalance balance, FinancialStatement financialStatement, bool isFinal, Account? parent = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Code = code;
            Name = name;
            Type = type;
            Group = group;
            Balance = balance;
            FinancialStatement = financialStatement;
            IsFinal = isFinal;
            if (parent is not null)
            {
                Parent = parent;
                ParentId = parent.Id;
            }
        }

        public void SetInventory(decimal inventory)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inventory, nameof(inventory));
            Inventory = inventory;
        }
    }
}
