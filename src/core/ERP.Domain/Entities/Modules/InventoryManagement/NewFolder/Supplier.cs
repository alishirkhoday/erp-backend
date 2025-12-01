namespace ERP.Domain.Entities.Modules.InventoryManagement.NewFolder
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
