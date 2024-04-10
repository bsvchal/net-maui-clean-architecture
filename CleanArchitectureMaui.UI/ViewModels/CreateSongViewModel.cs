using CleanArchitectureMaui.Application.MusicianUseCases.Queries;
using CleanArchitectureMaui.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CleanArchitectureMaui.UI.ViewModels
{
    [QueryProperty(nameof(Musician), "Musician")]
    public partial class CreateSongViewModel : ObservableObject, IQueryAttributable
    {
        public CreateSongViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
        private Musician _musician = null!;
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private int? chartPosition;
        [ObservableProperty]
        private string? album;
        [ObservableProperty]
        private double? rating;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _musician = (Musician)query["Musician"]!;
        }

        [RelayCommand]
        private async Task Create()
            => await CreateSongAsync();

        private async Task CreateSongAsync()
        {
            if (_musician is null)
            {
                return;
            }

            if (Song.AreValidFields(Name, ChartPosition, Album, Rating))
            {
                await _mediator.Send(
                    new AddSongRequest(
                        _musician,
                        Name!,
                        ChartPosition!.Value,
                        Album!, 
                        Rating!.Value));
            }

            await Shell.Current.GoToAsync(nameof(MusiciansPage));
        }
    }
}
