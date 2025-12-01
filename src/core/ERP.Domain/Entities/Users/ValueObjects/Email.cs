namespace ERP.Domain.Entities.Users.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; } = default!;

        private Email()
        {
        }

        private Email(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value.Trim();
        }

        public static implicit operator Email(string value)
        {
            return new Email(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
