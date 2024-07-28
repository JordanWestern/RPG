using MediatR;
using RPG.App.Contracts;

namespace RPG.App.Queries;

// TODO: logs should be part of the player domain object?
public record GetGameLogsQuery(Guid PlayerId) : IStreamRequest<GameLog>;
