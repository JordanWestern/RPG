using RPG.Domain.Entities;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;

namespace RPG.Infrastructure.Repositories;

public class PlayerRepository(PlayerDbContext context) : IPlayerRepository
{
    private readonly PlayerDbContext _context = context;

    public Task SaveNewPlayer(Player player, CancellationToken cancellationToken)
    {
        _context.Players.Add(player);
        _context.SaveChangesAsync(cancellationToken);
        return Task.CompletedTask;
    }

    public bool HasExistingPlayers() => _context.Players.Any();
    
    public IEnumerable<Player> GetExistingPlayers() => _context.Players;
}