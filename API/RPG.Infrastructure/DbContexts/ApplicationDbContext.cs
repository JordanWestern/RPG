using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;

namespace RPG.Infrastructure.DbContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; }
    public DbSet<GameLog> GameLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasKey(player => player.Id);
        modelBuilder.Entity<Player>().Property(player => player.Name).IsRequired();

        modelBuilder.Entity<GameLog>().HasKey(gameLog => gameLog.Id);
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.PlayerId).IsRequired();
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.Date).IsRequired();
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.LogMessage).IsRequired();
    }
}
