using System.Linq.Expressions;
using GoodsApi.Models;

namespace GoodsApi.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Read all entities
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> Read();

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <returns></returns>
    Task<TEntity> GetById(string id);

    /// <summary>
    /// Create new entity
    /// </summary>
    /// <returns></returns>
    Task<bool> Create(TEntity entity);

    /// <summary>
    /// Delete an entity
    /// </summary>
    /// <returns></returns>
    Task<bool> Delete(TEntity entity);

    /// <summary>
    /// Delete an entity by id
    /// </summary>
    /// <returns></returns>
    Task<bool> Delete(string id);

    /// <summary>
    /// Update an entity
    /// </summary>
    /// <returns></returns>
    Task<bool> Update(TEntity entity);
}