using MediatR;
using RPG.App.Contracts;

namespace RPG.App.Queries;

public record GetGameLogsQuery(Guid PlayerId) : IStreamRequest<GameLog>;
