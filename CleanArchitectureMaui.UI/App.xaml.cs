namespace CleanArchitectureMaui.UI
{
    public partial class App : IApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
