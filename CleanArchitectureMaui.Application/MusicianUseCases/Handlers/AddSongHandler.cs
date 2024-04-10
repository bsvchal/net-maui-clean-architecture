using CleanArchitectureMaui.Application.MusicianUseCases.Queries;

namespace CleanArchitectureMaui.Application.MusicianUseCases.Handlers
{
    public class AddSongHandler : IRequestHandler<AddSongRequest, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSongHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(AddSongRequest request, CancellationToken cancellationToken)
        {
            var musician = request.Musician;

            var song = new Song(
                request.SongName, request.ChartPosition, 
                request.Album, request.Rating, musician);

            musician.AddSong(song);

            await _unitOfWork
                .MusicianRepository
                .UpdateAsync(musician, cancellationToken);

            await _unitOfWork
                .SaveChangesAsync();

            await _unitOfWork
                .SongRepository
                .AddAsync(song, cancellationToken);

            await _unitOfWork
                .SaveChangesAsync();

            return song;
        }
    }
}
