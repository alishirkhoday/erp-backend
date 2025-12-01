namespace ERP.Domain.Entities.Modules.ReportingManagement
{
    public class Report : BaseEntity
    {
        public string Title { get; set; } = default!;
        public ReportType Type { get; set; }
        public string ContentJson { get; set; } = default!;
        public DateTime GeneratedAt { get; set; }
    }
}
