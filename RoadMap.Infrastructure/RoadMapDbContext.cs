using Microsoft.EntityFrameworkCore;
using RoadMap.Domain.RoadMap;
using RoadMap.Domain.Security;

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
    
    
    public DbSet<Admin> Admins { get; init; }
    public DbSet<Section> Sections { get; init; }
    
    public DbSet<Section> Specializations { get; init; }
}