namespace ERP.Domain.Entities.Modules.ReportingManagement
{
    public class DashboardWidget : BaseEntity
    {
        public Dashboard Dashboard { get; private set; } = default!;
        public ReportTemplate ReportTemplate { get; private set; } = default!;
        public int DisplayOrder { get; private set; } // ترتیب نمایش
        public string VisualizationType { get; private set; } = "Table"; // نوع نمایش (Table, Chart, KPI)

        public DashboardWidget(Dashboard dashboard, ReportTemplate reportTemplate, int displayOrder, string visualizationType = "Table")
        {
            Dashboard = dashboard;
            ReportTemplate = reportTemplate;
            DisplayOrder = displayOrder;
            VisualizationType = visualizationType;
        }
    }
}
