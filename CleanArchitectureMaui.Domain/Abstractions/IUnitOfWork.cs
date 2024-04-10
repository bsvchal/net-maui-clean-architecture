using CleanArchitectureMaui.Domain.Entities;

namespace CleanArchitectureMaui.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        public IRepository<Musician> MusicianRepository { get; }
        public IRepository<Song> SongRepository { get; }

        public Task SaveChangesAsync();
        public Task CreateDbAsync();
        public Task DeleteDbAsync();
    }
}
