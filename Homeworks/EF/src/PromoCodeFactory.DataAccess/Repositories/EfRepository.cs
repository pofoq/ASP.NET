using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.DataAccess.EFCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories;
public abstract class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly PromoCodeDbContext _context;
    private readonly DbSet<T> _entitySet;

    protected EfRepository(PromoCodeDbContext context)
    {
        _context = context;
        _entitySet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _entitySet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entitySet.FindAsync(id, cancellationToken);
    }

    public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var result = await _entitySet.AddAsync(entity, cancellationToken);
        await SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            return false;

        _entitySet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        //_context.Entry(entity).State = EntityState.Deleted;
        //await SaveChangesAsync(cancellationToken);
        return true;
    }

    private async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
