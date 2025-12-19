using RoadMap.Domain.Repository;

namespace RoadMap.Infrastructure.Repositories;

public class UnitOfWork: IUnitOfWork
{
    
    private readonly RoadMapDbContext  _context;
    public UnitOfWork(RoadMapDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);


    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}