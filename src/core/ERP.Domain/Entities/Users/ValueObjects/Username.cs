namespace ERP.Domain.Entities.Users.ValueObjects
{
    public class Username : ValueObject
    {
        public string Value { get; } = default!;

        private Username()
        {
        }

        private Username(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"value is null");
            }
            Value = value;
        }

        public static implicit operator Username(string value)
        {
            return new Username(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
