namespace ERP.Domain.Entities.Modules.HumanResourcesManagement.ValueObjects
{
    public class PassportId : ValueObject
    {
        public string Value { get; } = default!;

        private PassportId()
        {
        }

        private PassportId(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value.Trim();
        }

        public static implicit operator PassportId(string value)
        {
            return new PassportId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
