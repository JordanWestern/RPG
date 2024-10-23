using RPG.Domain.Events;

namespace RPG.Domain.Entities;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id must not be empty", nameof(id));
        }

        Id = id;
    }

    public Guid Id { get; }

    public List<IDomainEvent> DomainEvents { get; } = [];

    public void RaiseDomainEvent(IDomainEvent domainEvent) => DomainEvents.Add(domainEvent);
}
