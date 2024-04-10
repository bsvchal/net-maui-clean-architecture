using CleanArchitectureMaui.Persistence.Data;

namespace CleanArchitectureMaui.Persistence.Repository
{
    public class AppUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _songDbContext;
        private readonly Lazy<AppRepository<Musician>> _musicianRepository;
        private readonly Lazy<AppRepository<Song>> _songRepository;
        public IRepository<Musician> MusicianRepository => _musicianRepository.Value;
        public IRepository<Song> SongRepository => _songRepository.Value;

        public AppUnitOfWork(AppDbContext songDbContext)
        {   
            _songDbContext = songDbContext;
            _musicianRepository = new(() => 
                new AppRepository<Musician>(_songDbContext));
            _songRepository = new(() =>
                new AppRepository<Song>(_songDbContext));
        }

        public async Task CreateDbAsync() 
        {
            await _songDbContext.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDbAsync() 
        {
            await _songDbContext.Database.EnsureDeletedAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _songDbContext.SaveChangesAsync();
        }
    }
}
