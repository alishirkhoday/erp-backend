namespace ERP.Domain.Entities.Modules.ReportingManagement
{
    public class ReportExecution : BaseEntity
    {
        public ReportTemplate Template { get; private set; } = default!;
        public DateTimeOffset ExecutionDateTime { get; private set; } = DateTimeOffset.UtcNow;
        public string ExecutedBy { get; private set; } = default!; // کاربری که گزارش را اجرا کرده
        public string ResultSnapshot { get; private set; } = default!; // خروجی گزارش (به صورت JSON ذخیره می‌شود)

        public ReportExecution(ReportTemplate template, string executedBy, string resultSnapshot)
        {
            Template = template;
            ExecutedBy = executedBy;
            ResultSnapshot = resultSnapshot;
        }
    }
}
