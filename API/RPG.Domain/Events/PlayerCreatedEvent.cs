﻿using RPG.Domain.Entities;

namespace RPG.Domain.Events;

public sealed record PlayerCreatedEvent(Player Player) : IDomainEvent;
