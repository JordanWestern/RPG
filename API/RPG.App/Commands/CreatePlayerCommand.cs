﻿using MediatR;
using RPG.App.Contracts;

namespace RPG.App.Commands;

public record CreatePlayerCommand(NewPlayer NewPlayer) : IRequest<ExistingPlayer>;
