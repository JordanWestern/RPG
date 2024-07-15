using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;

namespace RPG.Infrastructure.DbContexts;

public class GameLogDbContext(DbContextOptions<GameLogDbContext> options) : DbContext(options)
{
    public DbSet<GameLog> GameLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameLog>().HasKey(gameLog => gameLog.Id);
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.PlayerId);
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.Date);
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.LogMessage).IsRequired();
    }
}