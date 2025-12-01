namespace ERP.Domain.Entities.Modules.WarehouseManagement
{
    public class WarehouseTransaction : BaseEntity
    {
        public Guid SourceLocationId { get; private set; }
        public WarehouseStorageLocation SourceLocation { get; private set; } = default!;
        public Guid DestinationLocationId { get; private set; }
        public WarehouseStorageLocation DestinationLocation { get; private set; } = default!;
        public WarehouseTransactionType Type { get; private set; }
        public WarehouseTransactionStatus Status { get; private set; }
        public DateTimeOffset TransactionEventDateTime { get; private set; }
        public string Description { get; private set; } = default!;
        public bool IsAutomatic { get; private set; }

        private readonly List<WarehouseTransactionItem> _items = [];
        public IReadOnlyList<WarehouseTransactionItem> Items => _items.AsReadOnly();

        private WarehouseTransaction()
        {
        }

        public WarehouseTransaction(WarehouseStorageLocation sourceLocation, WarehouseStorageLocation destinationLocation, DateTimeOffset transactionEventDateTime, WarehouseTransactionType type, string description, bool isAutomatic = false)
        {
            ArgumentNullException.ThrowIfNull(sourceLocation, nameof(sourceLocation));
            ArgumentNullException.ThrowIfNull(destinationLocation, nameof(destinationLocation));
            ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));
            SourceLocation = sourceLocation;
            SourceLocationId = sourceLocation.Id;
            DestinationLocation = destinationLocation;
            DestinationLocationId = destinationLocation.Id;
            TransactionEventDateTime = transactionEventDateTime;
            Type = type;
            Description = description;
            IsAutomatic = isAutomatic;
            Status = WarehouseTransactionStatus.Draft;
        }

        public void Update(DateTimeOffset transactionEventDateTime, string description)
        {
            ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));
            TransactionEventDateTime = transactionEventDateTime;
            Description = description;
        }

        public void ChangeStatus(WarehouseTransactionStatus status) => Status = status;

        public void AddItem(WarehouseTransactionItem transactionItem)
        {
            ArgumentNullException.ThrowIfNull(transactionItem, nameof(transactionItem));
            _items.Add(transactionItem);
        }

        public void RemoveItem(WarehouseTransactionItem transactionItem)
        {
            ArgumentNullException.ThrowIfNull(transactionItem, nameof(transactionItem));
            _items.Remove(transactionItem);
        }

        public void RemoveAllItems()
        {
            _items.Clear();
        }
    }
}
