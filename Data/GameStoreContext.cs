using Microsoft.EntityFrameworkCore;

namespace quick_e;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
 : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed the genre table
        modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Adventure" },
                new { Id = 3, Name = "Role-playing (RPG)" },
                new { Id = 4, Name = "Strategy" },
                new { Id = 5, Name = "Simulation" },
                new { Id = 6, Name = "Sports" },
                new { Id = 7, Name = "Puzzle" },
                new { Id = 8, Name = "Racing" },
                new { Id = 9, Name = "Fighting" },
                new { Id = 10, Name = "Horror" },
                new { Id = 11, Name = "Platformer" },
                new { Id = 12, Name = "Shooter" },
                new { Id = 13, Name = "Music/Rhythm" },
                new { Id = 14, Name = "Stealth" },
                new { Id = 15, Name = "Survival" },
                new { Id = 16, Name = "Open world" },
                new { Id = 17, Name = "Educational" },
                new { Id = 18, Name = "Card" },
                new { Id = 19, Name = "Party" },
                new { Id = 20, Name = "MMORPG" }
        );
    }
}
