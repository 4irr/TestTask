using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ApplicationContext _context;
        DbSet<TEntity> _dbSet;

        public EFRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public TEntity? FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public TEntity Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();

            return item;
        }

        public async Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
