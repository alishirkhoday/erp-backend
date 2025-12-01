namespace ERP.Domain.Primitives
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object?> GetEqualityComponents();

        public static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if (left is null ^ right is null)
                return false;

            return left is null || left.Equals(right);
        }

        public static bool NotEqualOperator(ValueObject? left, ValueObject? right) => !EqualOperator(left, right);
        public static bool operator ==(ValueObject? left, ValueObject? right) => EqualOperator(left, right);
        public static bool operator !=(ValueObject? left, ValueObject? right) => NotEqualOperator(left, right);

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode() => GetEqualityComponents().Aggregate(0, (hash, obj) => HashCode.Combine(hash, obj));
        public override string ToString() => string.Join(", ", GetEqualityComponents());
    }
}
