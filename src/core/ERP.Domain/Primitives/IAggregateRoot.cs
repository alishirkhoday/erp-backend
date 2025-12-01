namespace ERP.Domain.Primitives
{
    public interface IAggregateRoot<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}
