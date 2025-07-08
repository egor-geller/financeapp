using Microsoft.EntityFrameworkCore;

namespace fin.server.Data;

public static class DataExtensions
{
    public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<FinContext>();
        context.Database.Migrate();
        // context.Database.EnsureCreated();
    }
}