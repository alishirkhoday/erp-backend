using ERP.Domain.Entities.Modules.FinanceManagement.ValueObjects;

namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class FinancialYear : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public FinancialYearSetting Setting { get; private set; } = default!;

        private readonly List<Document> _documents = [];
        public IReadOnlyList<Document> Documents => _documents;

        private FinancialYear()
        {
        }

        public FinancialYear(string title, DateOnly startDate, DateOnly endDate)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            if (startDate < new DateOnly(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, DateTimeOffset.UtcNow.Day) || startDate > endDate)
                throw new ArgumentException("startDate should be greater than now and less than the endDate.");
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetSetting(FinancialYearSetting setting)
        {
            ArgumentNullException.ThrowIfNull(setting, nameof(setting));
            Setting = setting;
        }
    }
}
