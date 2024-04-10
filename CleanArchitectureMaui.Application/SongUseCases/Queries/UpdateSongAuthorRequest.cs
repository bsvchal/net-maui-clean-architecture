namespace CleanArchitectureMaui.Application.SongUseCases.Queries
{
    public record UpdateSongAuthorRequest(
        Song Song, Musician OldMusician, Musician NewMusician) : IRequest<Song>;
}
