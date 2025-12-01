namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanContactInformation : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public HumanContactType Type { get; private set; }
        public string Value { get; private set; } = default!;
        public string? Description { get; private set; }
        public bool IsDefault { get; private set; }

        private HumanContactInformation()
        {
        }

        public HumanContactInformation(Human human, HumanContactType type, string value)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            Human = human;
            Type = type;
            Value = value;
        }

        public void Update(HumanContactType type, string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            Type = type;
            Value = value;
        }

        public void SetIsDefault() => IsDefault = true;
        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
