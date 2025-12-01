namespace ERP.Domain.Primitives
{
    public abstract class BaseEntity : IAggregateRoot<Guid>
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset CreationDateTime { get; } = DateTimeOffset.UtcNow;
        public string? ConcurrencyStamp { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTimeOffset? ModificationDateTime { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public static bool operator ==(BaseEntity? firstEntity, BaseEntity? secondEntity)
        {
            return firstEntity is not null && secondEntity is not null && firstEntity.Equals(secondEntity);
        }

        public static bool operator !=(BaseEntity? firstEntity, BaseEntity? secondEntity)
        {
            return !(firstEntity == secondEntity);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not BaseEntity entity)
                return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void SetConcurrencyStamp()
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
        }

        public void SetModificationInformation(string modifiedBy)
        {
            ArgumentException.ThrowIfNullOrEmpty(modifiedBy, nameof(modifiedBy));
            ModifiedBy = modifiedBy;
            ModificationDateTime = DateTimeOffset.UtcNow;
        }
    }
}
