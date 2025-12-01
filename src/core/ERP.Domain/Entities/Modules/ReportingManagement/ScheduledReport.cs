namespace ERP.Domain.Entities.Modules.ReportingManagement
{
    public class ScheduledReport : BaseEntity
    {
        public ReportTemplate Template { get; private set; } = default!;
        public string CronExpression { get; private set; } = default!; // تعریف زمان‌بندی به فرمت Cron
        public string Recipients { get; private set; } = default!; // لیست گیرنده‌ها
        public bool IsActive { get; private set; }

        public ScheduledReport(ReportTemplate template, string cronExpression, string recipients)
        {
            Template = template;
            CronExpression = cronExpression;
            Recipients = recipients;
            IsActive = true;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
