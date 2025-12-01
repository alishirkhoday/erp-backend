namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class Tax : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public double Percentage { get; private set; }
        public bool IsActive { get; private set; }

        private Tax()
        {
        }

        public Tax(string title, double percentage)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(percentage, nameof(percentage));
            Title = title;
            Percentage = percentage;
        }

        public void Update(string title, double percentage)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(percentage, nameof(percentage));
            Title = title;
            Percentage = percentage;
        }

        public void SetActive() => IsActive = true;
        public void SetInactive() => IsActive = false;
    }
}
