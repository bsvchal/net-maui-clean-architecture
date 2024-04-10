using CleanArchitectureMaui.Application.MusicianUseCases.Queries;

namespace CleanArchitectureMaui.Application.MusicianUseCases.Handlers
{
    public class GetAllMusiciansHandler : IRequestHandler<GetAllMusiciansRequest, IEnumerable<Musician>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMusiciansHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Musician>> Handle(GetAllMusiciansRequest _, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .MusicianRepository
                .GetAllAsync(cancellationToken);
        }
    }
}
