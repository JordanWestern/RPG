using MediatR;
using RPG.App.Contracts;

namespace RPG.App.Requests
{
    public record CreatePlayerCommand(NewPlayer NewPlayer) : IRequest<ExistingPlayer>;
}
