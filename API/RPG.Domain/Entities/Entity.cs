using RPG.Domain.Events;

namespace RPG.Domain.Entities;

public abstract class Entity(Guid id)
{
    public Guid Id { get; } = id;

    public List<IDomainEvent> DomainEvents { get; } = [];

    public void RaiseDomainEvent(IDomainEvent domainEvent) => DomainEvents.Add(domainEvent);
}
