namespace CleanArchitectureMaui.Application.MusicianUseCases.Queries
{
    public record CreateMusicianRequest(
        string Name, int MonthListeners, string? ImagePath) : IRequest<Musician>;
}
