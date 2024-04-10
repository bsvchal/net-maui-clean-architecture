using CleanArchitectureMaui.Application.MusicianUseCases.Queries;
using CleanArchitectureMaui.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace CleanArchitectureMaui.UI.ViewModels
{
    public partial class CreateMusicianViewModel : ObservableObject
    {
        public CreateMusicianViewModel(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
        [ObservableProperty]
        private string name = string.Empty;
        [ObservableProperty]
        private int? monthListeners;
        public string? ImagePath { get; set; } = null;

        [RelayCommand]
        private async Task Create()
            => await CreateAsync();

        private async Task CreateAsync()
        {
            if (Musician.AreValidFields(Name, MonthListeners))
            {
                await _mediator.Send(
                    new CreateMusicianRequest(
                        Name, MonthListeners!.Value, ImagePath));

                await Shell.Current.GoToAsync(nameof(MusiciansPage));
            }
        }
    }
}
