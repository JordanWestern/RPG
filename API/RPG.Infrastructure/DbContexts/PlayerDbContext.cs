using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;

namespace RPG.Infrastructure.DbContexts;

public class PlayerDbContext(DbContextOptions<PlayerDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasKey(player => player.Id);
        modelBuilder.Entity<Player>().Property(player => player.Name).IsRequired();
    }
}
