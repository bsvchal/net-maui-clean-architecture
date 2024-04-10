using CleanArchitectureMaui.Application.SongUseCases.Queries;
using System.Runtime.InteropServices;

namespace CleanArchitectureMaui.Application.SongUseCases.Handlers
{
    public class UpdateSongRatingHandler : IRequestHandler<UpdateSongRatingRequest, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSongRatingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(UpdateSongRatingRequest request, CancellationToken cancellationToken)
        {
            var song = request.Song;

            song!.ChangeRating(request.Rating);

            await _unitOfWork
                .SongRepository
                .UpdateAsync(song, cancellationToken);

            await _unitOfWork
                .SaveChangesAsync();

            return song;
        }
    }
}
