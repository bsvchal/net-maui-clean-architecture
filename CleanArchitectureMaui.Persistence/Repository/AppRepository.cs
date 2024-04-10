using CleanArchitectureMaui.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureMaui.Persistence.Repository
{
    public class AppRepository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _songDbContext;
        private readonly DbSet<T> _songEntities;

        public AppRepository(AppDbContext songDbContext)
        {
            _songDbContext = songDbContext;
            _songEntities = _songDbContext.Set<T>();
        }

        public async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            await _songEntities.AddAsync(item, cancellationToken);
        }

        public async Task<T?> FirstOrDefaultAsync(Func<T, bool> filter, CancellationToken cancellationToken = default)
        {
            return await _songEntities
                .AsNoTracking()
                .Where(filter)
                .AsQueryable()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _songEntities
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Func<T, bool> filter, CancellationToken cancellationToken = default)
        {
            return (await _songEntities
                .AsNoTracking()
                .ToListAsync(cancellationToken))
                .Where(filter)
                .ToList();
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _songEntities
                .AsNoTracking()
                .Where(item => item.Id == id)
                .AsQueryable()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task RemoveAsync(T item, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => 
                _songEntities.Remove(item));
        }

        public async Task UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            _songDbContext.ChangeTracker.Clear();
            await Task.Run(() => 
                _songDbContext.Entry(item).State = EntityState.Modified);
        }

        public async Task SaveAllAsync(CancellationToken cancellationToken)
        {
            await _songDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
