using CleanArchitectureMaui.Application.MusicianUseCases.Queries;
using CleanArchitectureMaui.Application.SongUseCases.Queries;
using CleanArchitectureMaui.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CleanArchitectureMaui.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    public partial class ChangeSongAuthorViewModel : ObservableObject, IQueryAttributable
    {
        public ChangeSongAuthorViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
        [ObservableProperty]
        private Song song = null!;
        [ObservableProperty]
        private Musician selectedMusician = null!;
        public ObservableCollection<Musician> Musicians { get; private set; } = [];

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Song = (Song)query["Song"]!;
        }

        [RelayCommand]
        private async Task UpdateMusiciansList()
            => await GetMusicians();

        public async Task GetMusicians()
        {
            var musicians =
                await _mediator.Send(
            new GetAllMusiciansRequest());

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Musicians.Clear();

                foreach (var musician in musicians)
                {
                    Musicians.Add(musician);
                }
            });
        }

        [RelayCommand]
        private async Task Update()
            => await UpdateAuthor();

        private async Task UpdateAuthor()
        {
            if (SelectedMusician is not null)
            {
                await _mediator.Send(
                    new UpdateSongAuthorRequest(Song, Song.Musician!, SelectedMusician));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["Song"] = Song
            };

            await Shell.Current.GoToAsync(nameof(SongDetailsPage), parameters);
        }
    }
}
