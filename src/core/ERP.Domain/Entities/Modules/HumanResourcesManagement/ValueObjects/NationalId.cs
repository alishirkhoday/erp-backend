namespace ERP.Domain.Entities.Modules.HumanResourcesManagement.ValueObjects
{
    public class NationalId : ValueObject
    {
        public string Value { get; } = default!;

        private NationalId()
        {
        }

        private NationalId(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value.Trim();
        }

        public static implicit operator NationalId(string value)
        {
            return new NationalId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
