namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class PayrollReward : BaseEntity
    {
        public Payroll Payroll { get; private set; } = default!;
        public Reward Reward { get; private set; } = default!;

        private PayrollReward()
        {
        }

        public PayrollReward(Payroll payroll, Reward reward)
        {
            ArgumentNullException.ThrowIfNull(payroll, nameof(payroll));
            ArgumentNullException.ThrowIfNull(reward, nameof(reward));
            Payroll = payroll;
            Reward = reward;
        }
    }
}
