using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoadMap.Domain.Security;

namespace RoadMap.Infrastructure.Seed;

public static class DatabaseSeed
{


    public static async Task InitializeAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<RoadMapDbContext>();
        var wordHasherService = services.GetRequiredService<IWordHasherService>();
        var pendingMigration = await context.Database.GetPendingMigrationsAsync();
        if (!pendingMigration.Any())
        {
            await context.Database.MigrateAsync();
            
        }

        try
        {
            await SuperAdminSeed.SeedData(context,wordHasherService);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

}