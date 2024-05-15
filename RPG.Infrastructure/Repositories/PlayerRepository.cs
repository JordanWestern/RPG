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
    
    public void Save(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
    }

    public Player Load() => throw new NotImplementedException();
}