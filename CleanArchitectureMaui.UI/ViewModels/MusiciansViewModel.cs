using CleanArchitectureMaui.Application.MusicianUseCases.Queries;
using CleanArchitectureMaui.Application.SongUseCases.Queries;
using CleanArchitectureMaui.Domain.Entities;
using CleanArchitectureMaui.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;

namespace CleanArchitectureMaui.UI.ViewModels
{
    public partial class MusiciansViewModel : ObservableObject
    {
        public MusiciansViewModel(
            IMediator mediator)
        {
            _mediator = mediator;

            GetMusicians().Wait();
            selectedMusician = Musicians.First();
        }

        private readonly IMediator _mediator;
        public ObservableCollection<Musician> Musicians { get; private set; } = [];
        public ObservableCollection<Song> Songs { get; private set; } = [];

        [ObservableProperty]
        private Musician selectedMusician;

        [RelayCommand]
        private async Task UpdateMusiciansList()
            => await GetMusicians();
        [RelayCommand]
        private async Task UpdateSongsList() 
            => await GetSongs();
        [RelayCommand]
        private async Task ShowDetails(Song song)
            => await GoToDetailsPage(song);
        [RelayCommand]
        private async Task CreateMusician()
            => await GoToCreateMusicianPage();
        [RelayCommand]
        private async Task CreateSong(Musician musician)
            => await GoToCreateSongPage(musician);

        private async Task GoToCreateSongPage(Musician musician)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["Musician"] = musician
            };

            await Shell.Current.GoToAsync(nameof(CreateSongPage), parameters);
        }

        private async Task GoToCreateMusicianPage()
        {
            await Shell.Current.GoToAsync(nameof(CreateMusicianPage));
        }

        private async Task GoToDetailsPage(Song song)
        {
            var parameters = new Dictionary<string, object>() 
            {
                ["Song"] = song 
            };

            await Shell.Current.GoToAsync(nameof(SongDetailsPage), parameters);
        }

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

        public async Task GetSongs()
        {
            if (SelectedMusician is null)
            {
                return;
            }

            var songs =
                await _mediator.Send(
                    new GetAllSongsByIdRequest(SelectedMusician.Id));

            await MainThread.InvokeOnMainThreadAsync(() => 
            {
                Songs.Clear();  

                foreach (var song in songs)
                {
                    Songs.Add(song);
                }
            });
        }
    }
}
