using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RoadMap.Domain.Repository;
using RoadMap.Domain.RoadMap;

namespace RoadMap.Infrastructure.Repositories;

public class SectionRepository: BaseRepository<Section>, ISectionRepository
{
    public SectionRepository(RoadMapDbContext context) : base(context)
    {
    }

    public async Task<Section?> GetSectionByIdWithSpecializationAsync(Guid id)
    {
        return _context.Set<Section>()
            .AsNoTracking()
            
            .Include(x => x.Specializations)
            .FirstOrDefault(x=>x.Id==id);
    }
}