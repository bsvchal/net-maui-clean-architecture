using CleanArchitectureMaui.Application.SongUseCases.Queries;
using CleanArchitectureMaui.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CleanArchitectureMaui.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    public partial class UpdateSongRatingViewModel : ObservableObject, IQueryAttributable
    {
        public UpdateSongRatingViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private Song song = null!;
        [ObservableProperty]
        private double? rating;
        private readonly IMediator _mediator;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Song = (Song)query["Song"]!;
        }

        [RelayCommand]
        private async Task Update()
            => await UpdateRatingAsync();

        private async Task UpdateRatingAsync()
        {
            if (Song.IsValidRating(Rating))
            {
                await _mediator.Send(
                    new UpdateSongRatingRequest(Song, Rating!.Value));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["Song"] = Song
            };

            await Shell.Current.GoToAsync(nameof(SongDetailsPage), parameters);
        }
    }
}
