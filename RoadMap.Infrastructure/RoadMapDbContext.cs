using Microsoft.EntityFrameworkCore;
using RoadMap.Domain.RoadMap;

namespace RoadMap.Infrastructure;

public class RoadMapDbContext: DbContext
{

    public RoadMapDbContext(DbContextOptions<RoadMapDbContext> options): base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        base.OnModelCreating(builder);
    }
    
    public DbSet<Section> Sections { get; init; }
    
    public DbSet<Section> Specializations { get; init; }
}