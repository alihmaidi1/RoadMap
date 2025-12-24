using RoadMap.Domain.RoadMap;

namespace RoadMap.Domain.Repository;

public interface ISectionRepository: IBaseRepository<Section>
{
    
    public Task<Section?> GetSectionByIdWithSpecializationAsync(Guid id);
    
    
}