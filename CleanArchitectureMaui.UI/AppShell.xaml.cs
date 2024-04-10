using CleanArchitectureMaui.UI.Pages;
using System.Reflection;

namespace CleanArchitectureMaui.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(
                nameof(MusiciansPage),
                typeof(MusiciansPage));

            Routing.RegisterRoute(
                nameof(SongDetailsPage),
                typeof(SongDetailsPage));

            Routing.RegisterRoute(
                nameof(CreateMusicianPage),
                typeof(CreateMusicianPage));

            Routing.RegisterRoute(
                nameof(CreateSongPage),
                typeof(CreateSongPage));

            Routing.RegisterRoute(
                nameof(UpdateSongRatingPage),
                typeof(UpdateSongRatingPage));

            Routing.RegisterRoute(
                nameof(ChangeSongAuthorPage),
                typeof(ChangeSongAuthorPage));

            InitializeComponent();
        }
    }
}
