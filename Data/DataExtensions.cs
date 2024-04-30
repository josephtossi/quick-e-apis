using Microsoft.EntityFrameworkCore;

namespace quick_e;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        // execute migrate at startup //
        using var scope = app.Services.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        DbContext.Database.Migrate();
    }
}
