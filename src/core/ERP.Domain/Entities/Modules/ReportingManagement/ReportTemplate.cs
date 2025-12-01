namespace ERP.Domain.Entities.Modules.ReportingManagement
{
    public class ReportTemplate : BaseEntity
    {
        public string Name { get; private set; } = default!; // نام گزارش
        public string Description { get; private set; } = default!; // توضیح گزارش
        public ReportCategory Category { get; private set; } // دسته‌بندی (فروش، انبار، تولید، ...)
        public string QueryDefinition { get; private set; } = default!; // تعریف کوئری (SQL یا LINQ)
        public string OutputFormat { get; private set; } = "Table"; // نوع خروجی (Table, Chart, Pivot, Export)

        private readonly List<ReportFilterDefinition> _filters = new();
        public IReadOnlyList<ReportFilterDefinition> Filters => _filters;

        public ReportTemplate(string name, string description, ReportCategory category, string queryDefinition, string outputFormat = "Table")
        {
            Name = name;
            Description = description;
            Category = category;
            QueryDefinition = queryDefinition;
            OutputFormat = outputFormat;
        }

        public void AddFilter(ReportFilterDefinition filter) => _filters.Add(filter);
    }
}
