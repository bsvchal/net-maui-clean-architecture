using CleanArchitectureMaui.UI.ViewModels;

namespace CleanArchitectureMaui.UI.Pages;

public partial class MusiciansPage : ContentPage
{
    public MusiciansViewModel MusiciansViewModel { get; }
	public MusiciansPage(MusiciansViewModel musiciansViewModel)
	{
		InitializeComponent();

        MusiciansViewModel = musiciansViewModel;
        this.BindingContext = MusiciansViewModel;
    }
}