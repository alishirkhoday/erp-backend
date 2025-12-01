using System.Linq.Expressions;

namespace ERP.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : IAggregateRoot<TKey> where TKey : IEquatable<TKey>
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> IsExistenceByIdAsync(TKey key, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetListAsync<T>(Expression<Func<TEntity, T>> expression, Expression<Func<TEntity, bool>>? where = null, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetForOptionListAsync<T>(Expression<Func<TEntity, T>> expression, Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, object>>? orderby = null, CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : IAggregateRoot<Guid>
    {
        Task<TEntity?> GetByIdAsync(string key, CancellationToken cancellationToken = default);
        Task<bool> IsExistenceByIdAsync(string key, CancellationToken cancellationToken = default);
    }
}
