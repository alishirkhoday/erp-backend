namespace ERP.Domain.Entities.Modules.WarehouseManagement
{
    public enum WarehouseTransactionType
    {
        /// <summary>
        /// ورود به انبار
        /// </summary>
        Receipt = 1,
        /// <summary>
        /// خروج از انبار
        /// </summary>
        Remittance = 2,
        /// <summary>
        /// انتقال بین انبارهای داخل سازمان
        /// </summary>
        Transfer = 3
    }
}
