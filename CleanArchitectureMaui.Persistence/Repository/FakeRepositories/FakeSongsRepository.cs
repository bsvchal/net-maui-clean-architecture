
namespace CleanArchitectureMaui.Persistence.Repository.FakeRepositories
{
    public class FakeSongsRepository : IRepository<Song>
    {
        private readonly List<Song> _songs;

        public FakeSongsRepository()
        {
            _songs = [
                new Song("Asian Rock", 1, "Asian Rock", 9.9, null)
                    .SetAuthor("LAZER DIM 700"),
                new Song("Faneto Remix", 5, "Song Wars", 8.7, null)
                    .SetAuthor("LAZER DIM 700"),
                new Song("Wigan Out", 11, "Injoy", 8.5, null)
                    .SetAuthor("LAZER DIM 700"),
                new Song("Freestyle", 2, "Flxtra", 9.7, null)
                    .SetAuthor("osamason"),
                new Song("Need It", 3, "Flxtra", 9.5, null)
                    .SetAuthor("osamason"),
                new Song("Nothing", 7, "Flex Musix", 9.8, null)
                    .SetAuthor("osamason"),
                new Song("Gostyle 2023 Freestyle", 4, "Reverence", 9.9, null)
                    .SetAuthor("Jace!"),
                new Song("Oh Lord", 6, "The Leek 4!", 9.7, null)
                    .SetAuthor("Jace!"),
                new Song("C'mere!", 8, "The Leek 4!", 9.8, null)
                    .SetAuthor("Jace!")];
        }

        public Task AddAsync(Song item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Song?> FirstOrDefaultAsync(Func<Song, bool> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Song>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
                _songs);
        }

        public async Task<IReadOnlyList<Song>> GetAsync(Func<Song, bool> filter, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
                _songs
                    .Where(filter)
                    .ToList());
        }

        public Task<Song?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Song item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Song item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
