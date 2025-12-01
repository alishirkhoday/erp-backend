namespace ERP.Domain.Entities.Modules.FinanceManagement.ValueObjects
{
    public class FinancialYearSetting : ValueObject
    {
        public decimal BaseSalary { get; }

        private FinancialYearSetting()
        {
        }

        public FinancialYearSetting(decimal baseSalary)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(baseSalary, nameof(baseSalary));
            BaseSalary = baseSalary;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BaseSalary;
        }
    }
}
