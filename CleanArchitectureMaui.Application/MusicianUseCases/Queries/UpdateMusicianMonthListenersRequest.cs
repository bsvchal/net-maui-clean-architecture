namespace CleanArchitectureMaui.Application.MusicianUseCases.Queries
{
    public record UpdateMusicianMonthListenersRequest(
        Musician Musician, int MonthListeners) : IRequest<Musician>;
}
