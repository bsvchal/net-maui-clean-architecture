using CleanArchitectureMaui.UI.ViewModels;

namespace CleanArchitectureMaui.UI.Pages;

public partial class CreateSongPage : ContentPage
{
    private readonly CreateSongViewModel _createSongViewModel;

    public CreateSongPage(
		CreateSongViewModel createSongViewModel)
	{
		InitializeComponent();
        _createSongViewModel = createSongViewModel;

        BindingContext = _createSongViewModel;
    }
}