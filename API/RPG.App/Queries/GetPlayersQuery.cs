using MediatR;
using RPG.App.Contracts;

namespace RPG.App.Queries
{
    public record GetPlayersQuery : IStreamRequest<ExistingPlayer>;
}
