using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Primitives;
using ERP.Domain.Repositories;
using System.Linq.Expressions;

namespace ERP.Infrastructure.MainDatabase.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMainDbContext _context;
        protected readonly DbSet<TEntity> _entity;

        protected Repository(IMainDbContext context)
        {
            _context = context;
            _entity = _context.SetEntity<TEntity>();
        }

        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entity.AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _entity.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _entity.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<TEntity?> GetByIdAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await _entity.SingleOrDefaultAsync(e => e.Id == key, cancellationToken);
            return result;
        }

        public async Task<bool> IsExistenceByIdAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(e => e.Id == key, cancellationToken);
            return result;
        }

        public async Task<IReadOnlyList<T>> GetListAsync<T>(Expression<Func<TEntity, T>> expression, Expression<Func<TEntity, bool>>? where = null, CancellationToken cancellationToken = default)
        {
            var query = _entity.AsQueryable().AsNoTracking();
            if (where is not null)
            {
                query = query.Where(where);
            }
            var result = await query.Select(expression).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<TEntity?> GetByIdAsync(string key, CancellationToken cancellationToken = default)
        {
            var result = await _entity.SingleOrDefaultAsync(e => e.Id.ToString() == key, cancellationToken);
            return result;
        }

        public async Task<bool> IsExistenceByIdAsync(string key, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(e => e.Id.ToString() == key, cancellationToken);
            return result;
        }

        public async Task<IReadOnlyList<T>> GetForOptionListAsync<T>(Expression<Func<TEntity, T>> expression, Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, object>>? orderby = null, CancellationToken cancellationToken = default)
        {
            var query = _entity.AsQueryable().AsNoTracking();
            if (where is not null)
            {
                query = query.Where(where);
            }
            if (orderby is not null)
            {
                query = query.OrderBy(orderby);
            }
            var result = await query.Select(expression).Take(10).ToListAsync(cancellationToken);
            return result;
        }
    }
}
