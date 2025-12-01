using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionOrder : BaseEntity
    {
        public string Code { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public int Quantity { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; } = DateTimeOffset.UtcNow;
        public ProductionOrderStatus Status { get; private set; } = ProductionOrderStatus.Created;
        public DateTimeOffset? StartedDate { get; private set; }
        public DateTimeOffset? CompletedDate { get; private set; }

        private readonly List<ProductionTask> _tasks = [];
        public IReadOnlyList<ProductionTask> Tasks => _tasks;

        public ProductionOrder(string code, Item item, int quantity)
        {
            Code = code;
            Item = item;
            Quantity = quantity;
        }

        public void Start()
        {
            Status = ProductionOrderStatus.InProgress;
            StartedDate = DateTimeOffset.UtcNow;
        }

        public void Complete()
        {
            Status = ProductionOrderStatus.Completed;
            CompletedDate = DateTimeOffset.UtcNow;
        }
    }
}
