using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities.Common;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Concrete;

public class GenericRepository<TEntity>(AppDbContext _context) : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _table = _context.Set<TEntity>();
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public IQueryable<TEntity> GetQuery()
    {
        return _table;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
         _context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }
}