namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class PayrollDeduction : BaseEntity
    {
        public Payroll Payroll { get; private set; } = default!;
        public Deduction Deduction { get; private set; } = default!;

        private PayrollDeduction()
        {
        }

        public PayrollDeduction(Payroll payroll, Deduction deduction)
        {
            ArgumentNullException.ThrowIfNull(payroll, nameof(payroll));
            ArgumentNullException.ThrowIfNull(deduction, nameof(deduction));
            Payroll = payroll;
            Deduction = deduction;
        }
    }
}
