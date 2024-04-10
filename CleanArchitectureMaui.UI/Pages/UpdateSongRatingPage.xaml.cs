using CleanArchitectureMaui.UI.ViewModels;

namespace CleanArchitectureMaui.UI.Pages;

public partial class UpdateSongRatingPage : ContentPage
{
    private readonly UpdateSongRatingViewModel _updateSongRatingViewModel;

    public UpdateSongRatingPage(
		UpdateSongRatingViewModel updateSongRatingViewModel)
	{
		InitializeComponent();
        _updateSongRatingViewModel = updateSongRatingViewModel;
        BindingContext = _updateSongRatingViewModel;
    }
}