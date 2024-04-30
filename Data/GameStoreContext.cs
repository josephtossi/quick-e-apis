using Microsoft.EntityFrameworkCore;

namespace quick_e;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
 : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}
