using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;

namespace RPG.Infrastructure.DbContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; }

    public DbSet<GameLog> GameLogs { get; set; }

    public DbSet<PlayerLocation> PlayerLocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasKey(player => player.Id);
        modelBuilder.Entity<Player>().Property(player => player.Name).IsRequired();
        modelBuilder.Entity<Player>().Property(player => player.CurrentLocation).IsRequired();

        modelBuilder.Entity<GameLog>().HasKey(gameLog => gameLog.Id);
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.PlayerId).IsRequired();
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.Date).IsRequired();
        modelBuilder.Entity<GameLog>().Property(gameLog => gameLog.LogMessage).IsRequired();

        modelBuilder.Entity<PlayerLocation>().HasKey(location => location.Id);
        modelBuilder.Entity<PlayerLocation>().Property(location => location.MapId).IsRequired();
        modelBuilder.Entity<PlayerLocation>().Property(location => location.PlayerId).IsRequired();
        modelBuilder.Entity<PlayerLocation>().Property(location => location.Name).IsRequired();
        modelBuilder.Entity<PlayerLocation>().Property(location => location.Description).IsRequired();
        modelBuilder.Entity<PlayerLocation>().Property(location => location.Connections).IsRequired();
        modelBuilder.Entity<PlayerLocation>().Property(location => location.IsStartLocation).IsRequired();
    }
}
