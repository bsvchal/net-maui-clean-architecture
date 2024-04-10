
using System.Net.Http.Headers;

namespace CleanArchitectureMaui.Persistence.Repository.FakeRepositories
{
    public class FakeMusicianRepository : IRepository<Musician>
    {
        private readonly List<Musician> _musicians;

        public FakeMusicianRepository()
        {
            _musicians = [
                new Musician("LAZER DIM 700", 345000),
                new Musician("osamason", 781000),
                new Musician("Jace!", 992000)];
        }

        public Task AddAsync(Musician item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Musician?> FirstOrDefaultAsync(Func<Musician, bool> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Musician>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => 
                _musicians);
        }

        public Task<IReadOnlyList<Musician>> GetAsync(Func<Musician, bool> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Musician?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Musician item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Musician item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
