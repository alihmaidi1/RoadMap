using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RoadMap.Infrastructure;

public static class DependencyInjection
{



    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddDbContext<RoadMapDbContext>(options =>
        {
            
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
        });

        return services;

    }
    
}