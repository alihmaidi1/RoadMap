using Microsoft.EntityFrameworkCore;
using RoadMap.Domain.Base;
using RoadMap.Domain.Repository;

namespace RoadMap.Infrastructure.Repositories;

public class BaseRepository <TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {

        return await _context.Set<TEntity>().FindAsync(id);
    }
    
    
    
    public IQueryable<TEntity> GetQueryable()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {

        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {

        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;

    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);

    }

    
    
}