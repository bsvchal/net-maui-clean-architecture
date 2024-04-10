namespace CleanArchitectureMaui.Application.SongUseCases.Queries
{
    public record UpdateSongRatingRequest(Song Song, double Rating) : IRequest<Song>;
}
