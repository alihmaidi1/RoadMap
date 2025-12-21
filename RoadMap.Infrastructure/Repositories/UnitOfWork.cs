using Microsoft.EntityFrameworkCore.Storage;
using RoadMap.Domain.Repository;

namespace RoadMap.Infrastructure.Repositories;

public class UnitOfWork: IUnitOfWork
{
    
    private readonly RoadMapDbContext  _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(RoadMapDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public Task BeginTransactionAsync()
    {
        if (_transaction != null)
            return Task.CompletedTask;
        _transaction=_context.Database.BeginTransaction();
        return Task.CompletedTask;
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction == null)
            throw new InvalidOperationException("No active transaction");
        await _context.SaveChangesAsync();
        _transaction.Commit();
        await DisposeTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
            return;
        await _transaction.RollbackAsync();
        await DisposeTransactionAsync();
    }

    private async Task DisposeTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}