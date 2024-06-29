using RPG.Domain.Entities;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;

namespace RPG.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly PlayerDbContext _context;

    public PlayerRepository(PlayerDbContext context)
    {
        _context = context;
    }
    
    public void SaveNewPlayer(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
    }

    public bool HasExistingPlayers() => _context.Players.Any();
    
    public IEnumerable<Player> GetExistingPlayers() => _context.Players;
}