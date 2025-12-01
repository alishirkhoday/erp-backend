namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public enum AccountType
    {
        /// <summary>
        /// دارایی جاری
        /// </summary>
        AssetCurrent = 0,
        /// <summary>
        /// دارایی غیرجاری مشهود
        /// </summary>
        AssetNonCurrentTangible = 1,
        /// <summary>
        /// دارایی غیرجاری نامشهود
        /// </summary>
        AssetNonCurrentIntangible = 2,
        /// <summary>
        /// بدهی جاری
        /// </summary>
        LiabilityCurrent = 3,
        /// <summary>
        /// بدهی غیر جاری
        /// </summary>
        LiabilityNonCurrent = 4,
        /// <summary>
        /// حقوق صاحبان سهام
        /// </summary>
        Equity = 5,
        /// <summary>
        /// درآمد عملیاتی
        /// </summary>
        RevenueOperating = 6,
        /// <summary>
        /// درآمد غیرعملیاتی
        /// </summary>
        RevenueNonOperating = 7,
        /// <summary>
        /// هزینه عملیاتی
        /// </summary>
        ExpenseOperating = 8,
        /// <summary>
        /// هزینه غیرعملیاتی
        /// </summary>
        ExpenseNonOperating = 9,
        /// <summary>
        /// کاهنده دارایی
        /// </summary>
        AssetDecrease = 10,
        /// <summary>
        /// کاهنده بدهی
        /// </summary>
        LiabilityDecrease = 11,
        /// <summary>
        /// بهای تمام شده
        /// </summary>
        CostPriceProductSold = 12,
        /// <summary>
        /// سایر
        /// </summary>
        Other = 13
    }
}
