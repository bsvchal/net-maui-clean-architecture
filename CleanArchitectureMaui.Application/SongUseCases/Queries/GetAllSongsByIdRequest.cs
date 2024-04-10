namespace CleanArchitectureMaui.Application.SongUseCases.Queries
{
    public record GetAllSongsByIdRequest(int Id) : IRequest<IEnumerable<Song>>;
}
