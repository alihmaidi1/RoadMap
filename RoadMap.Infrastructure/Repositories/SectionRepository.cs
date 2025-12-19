using RoadMap.Domain.Repository;
using RoadMap.Domain.RoadMap;

namespace RoadMap.Infrastructure.Repositories;

public class SectionRepository: BaseRepository<Section>, ISectionRepository
{
    public SectionRepository(RoadMapDbContext context) : base(context)
    {
    }
    
    
}