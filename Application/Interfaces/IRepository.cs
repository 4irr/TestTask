namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity item);
        Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken);
        TEntity? FindById(Guid id);
        Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
        IEnumerable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
