
namespace CleanArchitectureMaui.Persistence.Repository.FakeRepositories
{
    public class FakeSongUnitOfWork : IUnitOfWork
    {
        private readonly Lazy<FakeMusicianRepository> _musicianRepository;
        private readonly Lazy<FakeSongsRepository> _songsRepository;

        public IRepository<Musician> MusicianRepository
            => _musicianRepository.Value;
        public IRepository<Song> SongRepository 
            => _songsRepository.Value;

        public FakeSongUnitOfWork()
        {
            _musicianRepository = new(() => new FakeMusicianRepository());
            _songsRepository = new(() => new FakeSongsRepository());
        }

        public Task CreateDbAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteDbAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
