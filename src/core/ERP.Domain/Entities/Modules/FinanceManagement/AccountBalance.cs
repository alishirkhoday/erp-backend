namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public enum AccountBalance
    {
        /// <summary>
        /// بدهکار
        /// </summary>
        Debtor = 0,
        /// <summary>
        /// بستانکار
        /// </summary>
        Creditor = 1,
        /// <summary>
        /// خنثی
        /// </summary>
        Both = 2
    }
}
