using CleanArchitectureMaui.UI.Pages;
using CleanArchitectureMaui.UI.ViewModels;
using System.Runtime.CompilerServices;

namespace CleanArchitectureMaui.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            return services
                .AddTransient<MusiciansPage>()
                .AddTransient<SongDetailsPage>()
                .AddTransient<CreateMusicianPage>()
                .AddTransient<CreateSongPage>()
                .AddTransient<UpdateSongRatingPage>()
                .AddTransient<ChangeSongAuthorPage>();
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services) 
        {
            return services
                .AddTransient<MusiciansViewModel>()
                .AddTransient<SongDetailsViewModel>()
                .AddTransient<CreateMusicianViewModel>()
                .AddTransient<CreateSongViewModel>()
                .AddTransient<UpdateSongRatingViewModel>()
                .AddTransient<ChangeSongAuthorViewModel>();
        }
    }
}
