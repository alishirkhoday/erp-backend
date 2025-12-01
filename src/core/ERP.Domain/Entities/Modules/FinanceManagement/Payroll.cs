using ERP.Domain.Entities.Modules.HumanResourcesManagement;

namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class Payroll : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public PayrollStatus Status { get; private set; }

        private readonly List<PayrollReward> _rewards = [];
        public IReadOnlyList<PayrollReward> Rewards => _rewards;

        private readonly List<PayrollDeduction> _deductions = [];
        public IReadOnlyList<PayrollDeduction> Deductions => _deductions;

        private Payroll()
        {
        }

        public Payroll(Human human, DateOnly startDate, DateOnly endDate)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            if (startDate > endDate)
                throw new ArgumentException("endDate should be greater than startDate", $"{nameof(startDate)}");
            Human = human;
            StartDate = startDate;
            EndDate = endDate;
            Status = PayrollStatus.Draft;
        }

        public void Update(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("endDate should be greater than startDate", $"{nameof(startDate)}");
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
