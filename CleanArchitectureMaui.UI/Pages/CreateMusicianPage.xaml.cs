using CleanArchitectureMaui.UI.ViewModels;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureMaui.UI.Pages;

public partial class CreateMusicianPage : ContentPage
{
    private readonly CreateMusicianViewModel _createMusicianViewModel;

    public CreateMusicianPage(
		CreateMusicianViewModel createMusicianViewModel)
	{
		InitializeComponent();
        _createMusicianViewModel = createMusicianViewModel;
		this.BindingContext = _createMusicianViewModel;
    }

	public void OnImagePickerClicked(object sender, EventArgs _)
	{
		FileResult? file = null;

		Task.Run(async () => 
		{
			file = await FilePicker.Default.PickAsync(PickOptions.Images);
		}).Wait();

		if (file is not null)
		{
			_createMusicianViewModel.ImagePath = file.FullPath;
		}
	}
}