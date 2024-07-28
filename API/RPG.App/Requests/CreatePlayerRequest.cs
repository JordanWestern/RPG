using MediatR;
using RPG.App.Contracts;

namespace RPG.App.Requests
{
    public record CreatePlayerRequest(NewPlayer NewPlayer) : IRequest<CreatePlayerResponse>;
}
