namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class TaskAssignment : BaseEntity
    {
        public ProductionTask Task { get; private set; } = default!;
        public Operator Operator { get; private set; } = default!;
        public Shift Shift { get; private set; } = default!;
        public DateTimeOffset AssignedAt { get; private set; } = DateTimeOffset.UtcNow;

        public TaskAssignment(ProductionTask task, Operator @operator, Shift shift)
        {
            Task = task;
            Operator = @operator;
            Shift = shift;
        }
    }
}
