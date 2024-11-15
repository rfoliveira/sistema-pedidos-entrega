using Microsoft.EntityFrameworkCore;
using SisLog.Domain.Entities;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace SisLog.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly SisLogContext DbContext;
    private readonly DbSet<TEntity> _entity;

    protected BaseRepository(SisLogContext dbContext)
    {
        DbContext = dbContext;
        _entity = DbContext.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return (predicate != null)
            ? await _entity.AsNoTracking().Where(predicate).ToListAsync()
            : await _entity.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {

        _entity.Add(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.AtualizadoEm = DateTime.UtcNow;
        _entity.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(TEntity entity, bool logicalDelete = true)
    {
        try
        {
            if (logicalDelete)
            {
                entity.RemovidoEm = DateTime.UtcNow;
                _entity.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _entity.Remove(entity);
            }

            await DbContext.SaveChangesAsync();
            return true;
        }
        catch (DbException)
        {
            return false;
        }
    }
}
