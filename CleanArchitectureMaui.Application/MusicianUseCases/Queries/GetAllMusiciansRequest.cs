namespace CleanArchitectureMaui.Application.MusicianUseCases.Queries
{
    public record GetAllMusiciansRequest() : IRequest<IEnumerable<Musician>>;
}
