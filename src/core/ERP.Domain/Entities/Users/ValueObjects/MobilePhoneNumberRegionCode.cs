namespace ERP.Domain.Entities.Users.ValueObjects
{
    public class MobilePhoneNumberRegionCode : ValueObject
    {
        public string Value { get; } = default!;

        private MobilePhoneNumberRegionCode()
        {
        }

        private MobilePhoneNumberRegionCode(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value.Trim();
        }

        public static implicit operator MobilePhoneNumberRegionCode(string value)
        {
            return new MobilePhoneNumberRegionCode(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
