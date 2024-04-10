using CleanArchitectureMaui.Domain.Entities;

namespace CleanArchitectureMaui.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<T>> GetAsync(Func<T, bool> filter, CancellationToken cancellationToken = default);
        public Task AddAsync(T item, CancellationToken cancellationToken = default);
        public Task UpdateAsync(T item, CancellationToken cancellationToken = default);
        public Task RemoveAsync(T item, CancellationToken cancellationToken = default);
        public Task<T?> FirstOrDefaultAsync(Func<T, bool> filter, CancellationToken cancellationToken = default);
        public Task SaveAllAsync(CancellationToken cancellationToken = default);
    }
}
