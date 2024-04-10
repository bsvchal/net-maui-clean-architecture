namespace CleanArchitectureMaui.Application.MusicianUseCases.Queries
{
    public record AddSongRequest(
        Musician Musician, string SongName, int ChartPosition,
        string Album, double Rating) : IRequest<Song>;
}
