namespace ERP.Domain.Entities.Modules.OrderManagement
{
    public class DiscountCode : BaseEntity
    {
        public string Code { get; private set; } = default!;
        public decimal DiscountAmount { get; private set; }
        public DateTimeOffset ExpireDate { get; private set; }
        public bool IsPercentage { get; private set; }

        private DiscountCode()
        {
        }

        public DiscountCode(string code, decimal discountAmount, DateTimeOffset expireDate, bool isPercentage)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            Code = "GeneratedCode";
            DiscountAmount = discountAmount;
            ExpireDate = expireDate;
            IsPercentage = isPercentage;
        }
    }
}
