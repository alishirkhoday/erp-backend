namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class Deduction : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public decimal Amount { get; private set; }
        public string? Description { get; private set; }

        private readonly List<PayrollDeduction> _deductions = [];
        public IReadOnlyList<PayrollDeduction> Deductions => _deductions;

        private Deduction()
        {
        }

        public Deduction(string title, decimal amount)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, nameof(amount));
            Title = title;
            Amount = amount;
        }

        public void Update(string title, decimal amount)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, nameof(amount));
            Title = title;
            Amount = amount;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
