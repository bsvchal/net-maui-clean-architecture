
using CleanArchitectureMaui.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CleanArchitectureMaui.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    public partial class SongDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Song song = null!;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Song = (Song)query["Song"];
        }

        [RelayCommand]
        private async Task UpdateRating(Song song)
            => await GoToUpdateRatingPage(song);

        private async Task GoToUpdateRatingPage(Song song)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["Song"] = song
            };

            await Shell.Current.GoToAsync(nameof(UpdateSongRatingPage), parameters);
        }

        [RelayCommand]
        private async Task UpdateAuthor(Song song)
            => await GoToUpdateAuthorPage(song);

        private async Task GoToUpdateAuthorPage(Song song)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["Song"] = song
            };

            await Shell.Current.GoToAsync(nameof(ChangeSongAuthorPage), parameters);
        }
    }
}
