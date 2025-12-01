namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class Bank : BaseEntity
    {
        public string Name { get; private set; } = default!;

        private readonly List<BankBranch> _branches = [];
        public IReadOnlyList<BankBranch> Branches => _branches;

        private Bank()
        {
        }

        public Bank(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void Update(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void AddBranch(BankBranch branch) => _branches.Add(branch);
    }
}
