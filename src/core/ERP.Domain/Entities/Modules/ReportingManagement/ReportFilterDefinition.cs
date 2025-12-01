namespace ERP.Domain.Entities.Modules.ReportingManagement
{
    public class ReportFilterDefinition : BaseEntity
    {
        public ReportTemplate Template { get; private set; } = default!;
        public string FieldName { get; private set; } = default!;
        public FilterType Type { get; private set; }
        public string? DefaultValue { get; private set; }

        public ReportFilterDefinition(ReportTemplate template, string fieldName, FilterType type, string? defaultValue = null)
        {
            Template = template;
            FieldName = fieldName;
            Type = type;
            DefaultValue = defaultValue;
        }
    }
}
