using CleanArchitectureMaui.Application.SongUseCases.Queries;

namespace CleanArchitectureMaui.Application.SongUseCases.Handlers
{
    public class GetAllSongsByIdHandler : IRequestHandler<GetAllSongsByIdRequest, IEnumerable<Song>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSongsByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Song>> Handle(GetAllSongsByIdRequest request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork
                .MusicianRepository
                .GetByIdAsync(request.Id);

            return (await _unitOfWork
                .SongRepository
                .GetAsync(song => song.MusicianId == request.Id, cancellationToken))
                .Select(item => item.SetAuthor(author!));
        }
    }
}
