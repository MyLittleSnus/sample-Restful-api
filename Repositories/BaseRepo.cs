using System.Linq.Expressions;
using GoodsApi.Context;
using GoodsApi.Models;
using GoodsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodsApi.Repositories;

public class BaseRepo<TEntity> : IBaseRepository<TEntity>
	where TEntity : BaseEntity
{
	protected readonly ShopContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public BaseRepo(ShopContext context)
	{
		_dbContext = context;
		_dbSet = _dbContext.Set<TEntity>();
	}

	public async Task<IQueryable<TEntity>> Read() => await Task.Run(_dbSet.AsQueryable);

	public async Task<bool> Create(TEntity entity)
	{
		await _dbSet.AddAsync(entity);

		return (await _dbContext.SaveChangesAsync()) > 0 ? true : false;
    }

	public async Task<bool> Delete(TEntity entity)
	{
		_dbSet.Remove(entity);

        return (await _dbContext.SaveChangesAsync()) > 0 ? true : false;
    }

	public async Task<bool> Delete(string id)
	{
		var entity = await GetById(id);
			
        _dbSet.Remove(entity);

		return (await _dbContext.SaveChangesAsync()) > 0 ? true : false;
	}

	public async Task<bool> Update(TEntity entity)
	{
		_dbSet.Entry(entity).State = EntityState.Modified;

        return (await _dbContext.SaveChangesAsync()) > 0 ? true : false;
    }

    public void IncludeSingle(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties)
	{
		foreach (var property in includeProperties)
		{
            _dbContext.Entry(entity).Reference(property!).Load();
        }
	}

	public void IncludeMultiple(TEntity entity, params Expression<Func<TEntity, IEnumerable<object>>>[] includeProperties)
	{
        foreach (var property in includeProperties)
        {
            _dbContext.Entry(entity).Collection(property).Load();
        }
    }

    public async Task<TEntity> GetById(string id)
		=> await _dbSet.Where(e => e.Id == id).FirstAsync();
}