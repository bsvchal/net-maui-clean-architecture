using CleanArchitectureMaui.UI.ViewModels;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureMaui.UI.Pages;

public partial class SongDetailsPage : ContentPage
{
    private readonly string _imageStoringPath;

    public SongDetailsViewModel SongDetails { get; }
	public SongDetailsPage(
        SongDetailsViewModel songDetailsViewModel,
        IConfiguration configuration)
	{
		InitializeComponent();
		
		SongDetails = songDetailsViewModel;
		this.BindingContext = SongDetails;

        _imageStoringPath = configuration["ImageStoringOptions:ImageSourcePath"]!;
	}

	public void OnImageCreateClicked(object sender, EventArgs _)
	{
        FileResult? file = null;

        Task.Run(async () =>
        {
            file = await FilePicker.Default.PickAsync(PickOptions.Images);
        }).Wait();

        if (file is not null)
        {
			var image = SongDetails.Song.CopyImage(file.FullPath, _imageStoringPath);
        }
    }
}