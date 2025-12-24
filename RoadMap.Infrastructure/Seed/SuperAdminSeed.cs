using RoadMap.Domain.Security;

namespace RoadMap.Infrastructure.Seed;

public class SuperAdminSeed
{

    public async static Task SeedData(RoadMapDbContext context,IWordHasherService wordHasherService)
    {

        if (!context.Admins.Any())
        {
            var admin = Admin.Create("superadmin","12345678",true,wordHasherService);
            context.Admins.Add(admin);
            
        }
        
    }
}