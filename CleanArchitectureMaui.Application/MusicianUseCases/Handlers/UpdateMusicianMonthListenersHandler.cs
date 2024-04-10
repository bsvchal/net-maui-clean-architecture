using CleanArchitectureMaui.Application.MusicianUseCases.Queries;

namespace CleanArchitectureMaui.Application.MusicianUseCases.Handlers
{
    public class UpdateMusicianMonthListenersHandler : IRequestHandler<UpdateMusicianMonthListenersRequest, Musician>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMusicianMonthListenersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Musician> Handle(UpdateMusicianMonthListenersRequest request, CancellationToken cancellationToken)
        {
            var musician = request.Musician;

            musician.ChangeMonthListenersAmount(request.MonthListeners);

            await _unitOfWork
                .MusicianRepository
                .UpdateAsync(musician);

            await _unitOfWork
                .SaveChangesAsync();

            return musician;
        }
    }
}
