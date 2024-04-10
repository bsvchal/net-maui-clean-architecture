using CleanArchitectureMaui.Application.SongUseCases.Queries;

namespace CleanArchitectureMaui.Application.SongUseCases.Handlers
{
    public class UpdateSongAuthorHandler : IRequestHandler<UpdateSongAuthorRequest, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSongAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(UpdateSongAuthorRequest request, CancellationToken cancellationToken)
        {
            var song = request.Song;
            var oldMusician = request.OldMusician;
            var newMusician = request.NewMusician;

            if (oldMusician == newMusician)
            {
                return new();
            }

            song.SetAuthor(newMusician);
            oldMusician.RemoveSong(song);
            newMusician.AddSong(song);

            await _unitOfWork
                .MusicianRepository
                .UpdateAsync(oldMusician, cancellationToken);

            await _unitOfWork
                .MusicianRepository
                .UpdateAsync(newMusician, cancellationToken);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork
                .SongRepository
                .UpdateAsync(song, cancellationToken);

            await _unitOfWork.SaveChangesAsync();

            return song;
        }
    }
}
