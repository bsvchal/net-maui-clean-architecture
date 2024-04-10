using CleanArchitectureMaui.Application.MusicianUseCases.Queries;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureMaui.Application.MusicianUseCases.Handlers
{
    public class CreateMusicianHandler
        : IRequestHandler<CreateMusicianRequest, Musician>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _imageStoringPath;

        public CreateMusicianHandler(
            IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _imageStoringPath = configuration["ImageStoringOptions:ImageSourcePath"]!;
        }

        public async Task<Musician> Handle(CreateMusicianRequest request, CancellationToken cancellationToken)
        {
            var musician = new Musician(
                request.Name, request.MonthListeners);

            if (request.ImagePath is not null)
            {
                musician.CopyImage(request.ImagePath, _imageStoringPath);
            }

            await _unitOfWork
                .MusicianRepository
                .AddAsync(musician, cancellationToken);

            await _unitOfWork
                .SaveChangesAsync();

            return musician;
        }
    }
}
