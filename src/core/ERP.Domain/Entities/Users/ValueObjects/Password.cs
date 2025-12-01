namespace ERP.Domain.Entities.Users.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; } = default!;

        private Password()
        {
        }

        private Password(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value;
        }

        public static implicit operator Password(string value)
        {
            return new Password(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
