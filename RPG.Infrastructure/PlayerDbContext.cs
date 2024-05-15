using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;

namespace RPG.Infrastructure;

public class PlayerDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("Players");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasKey(player => player.Id);
        modelBuilder.Entity<Player>().Property(player => player.Name).IsRequired();
    }
}