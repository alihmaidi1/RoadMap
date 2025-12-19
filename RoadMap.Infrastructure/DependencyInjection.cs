using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadMap.Domain.Repository;
using RoadMap.Infrastructure.Repositories;

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


        services.Scan(scan=>scan
            .FromAssemblyOf<RoadMapDbContext>()
            .AddClasses(c=>c.AssignableTo(typeof(IBaseRepository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        return services;

    }
    
}