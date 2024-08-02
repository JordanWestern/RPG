using RPG.Domain.Entities;

namespace RPG.Domain.Events;

public sealed record GameLogCreatedEvent(GameLog GameLog) : IDomainEvent;