using System.Linq.Expressions;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Application.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : BaseEntity
{

    Task<List<TEntity>> GetAllAsync();

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

    IQueryable<TEntity> GetQuery();

    Task<TEntity> GetByIdAsync(Guid id);

    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

    Task CreateAsync(TEntity  entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}