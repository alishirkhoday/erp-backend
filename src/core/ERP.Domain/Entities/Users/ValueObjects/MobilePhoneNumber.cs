namespace ERP.Domain.Entities.Users.ValueObjects
{
    public class MobilePhoneNumber : ValueObject
    {
        public string Value { get; } = default!;

        private MobilePhoneNumber()
        {
        }

        private MobilePhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value.Trim();
        }

        public static implicit operator MobilePhoneNumber(string value)
        {
            return new MobilePhoneNumber(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
