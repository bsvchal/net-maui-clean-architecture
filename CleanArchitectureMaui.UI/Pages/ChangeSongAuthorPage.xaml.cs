using CleanArchitectureMaui.UI.ViewModels;

namespace CleanArchitectureMaui.UI.Pages;

public partial class ChangeSongAuthorPage : ContentPage
{
    private readonly ChangeSongAuthorViewModel _changeSongAuthorViewModel;

    public ChangeSongAuthorPage(
		ChangeSongAuthorViewModel changeSongAuthorViewModel)
	{
		InitializeComponent();
        _changeSongAuthorViewModel = changeSongAuthorViewModel;
        BindingContext = _changeSongAuthorViewModel;
    }
}