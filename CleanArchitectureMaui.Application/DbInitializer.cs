using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureMaui.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(
            IServiceProvider services,
            IConfiguration configuration)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            var defaultImagePath = configuration["ImageStoringOptions:DefaultImagePath"]!;

            await unitOfWork.DeleteDbAsync();
            await unitOfWork.CreateDbAsync();

            List<Musician> musicians = [
                new Musician("LAZER DIM 700", 345000),
                new Musician("osamason", 781000),
                new Musician("Jace!", 992000)];

            foreach (var musician in musicians)
            {
                musician.AddProfilePicture(defaultImagePath);
                await unitOfWork.MusicianRepository.AddAsync(musician);
            }

            await unitOfWork.SaveChangesAsync();

            List<Song> songs = [
                new Song("Asian Rock", 1, "Asian Rock", 9.9, null)
                    .SetAuthor("LAZER DIM 700"),
                new Song("Faneto Remix", 5, "Song Wars", 8.7, null)
                    .SetAuthor("LAZER DIM 700"),
                new Song("Wigan Out", 11, "Injoy", 8.5, null)
                    .SetAuthor("LAZER DIM 700"),
                new Song("Freestyle", 2, "Flxtra", 9.7, null)
                    .SetAuthor("osamason"),
                new Song("Need It", 3, "Flxtra", 9.5, null)
                    .SetAuthor("osamason"),
                new Song("Nothing", 7, "Flex Musix", 9.8, null)
                    .SetAuthor("osamason"),
                new Song("Gostyle 2023 Freestyle", 4, "Reverence", 9.9, null)
                    .SetAuthor("Jace!"),
                new Song("Oh Lord", 6, "The Leek 4!", 9.7, null)
                    .SetAuthor("Jace!"),
                new Song("C'mere!", 8, "The Leek 4!", 9.8, null)
                    .SetAuthor("Jace!")];

            foreach (var song in songs)
            {
                await unitOfWork.SongRepository.AddAsync(song);
            }

            await unitOfWork.SaveChangesAsync();
        }
    }
}
