using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using CleanArchitectureMaui.Persistence;
using CleanArchitectureMaui.Application;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureMaui.Persistence.Data;

namespace CleanArchitectureMaui.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var settingsStream = "CleanArchitectureMaui.UI.appsettings.json";
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream!);

            var connectionString = builder.Configuration
                .GetConnectionString("DbConnection");
            var directory = FileSystem.Current.AppDataDirectory + "/";
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(string.Format(connectionString!, directory))
                .Options;

            builder.Services
                .AddApplication()
                .AddPersistence(options)
                .RegisterPages()
                .RegisterViewModels();

            /*DbInitializer.Initialize(
                builder.Services.BuildServiceProvider(),
                builder.Configuration).Wait();*/

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
