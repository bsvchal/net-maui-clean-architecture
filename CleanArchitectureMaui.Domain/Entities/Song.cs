using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace CleanArchitectureMaui.Domain.Entities
{
    public class Song : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public int ChartPosition { get; private set; } = 0;
        public string Album { get; private set; } = string.Empty;
        public double Rating { get; private set; } = 0.0;
        public int MusicianId { get; private set; } = 0;
        public Musician? Musician { get; private set; } 
                
        public Song() { }

        public Song(string name, int chartPosition, string album,
                    double rating, Musician? musician)
        {
            Id = BitConverter.ToInt32
            (
                SHA256.HashData(Encoding.UTF8.GetBytes
                (
                    new StringBuilder()
                    .Append(name)
                    .Append(Album)
                    .ToString()
                ))
            );
            Name = name;
            ChartPosition = chartPosition;
            Album = album;
            Rating = rating;
            MusicianId = musician is null ? 0 : musician.Id;
            Musician = musician;
        }

        public static bool AreValidFields(
            string? name, int? chartPosition,
            string? album, double? rating)
        {
            if (name is null ||
                chartPosition is null ||
                album is null ||
                rating is null)
            {
                return false;
            }

            return chartPosition > 0 && chartPosition <= 100 &&
                rating >= 0.0 && rating <= 10.0;
        }

        public static bool IsValidRating(double? value)
            => value is not null && value >= 0.0 && value <= 10.0;

        public static string GetHashedName(string name)
        {
            return BitConverter.ToString(
                SHA256.HashData(Encoding.UTF8.GetBytes(name)))
                    .Replace("-", "")
                    .ToLower();
        }

        public Song SetAuthor(string musicianName)
        {
            MusicianId = BitConverter.ToInt32
            (
                SHA256.HashData(Encoding.UTF8.GetBytes(musicianName))
            );

            return this;
        }

        public Song SetAuthor(Musician musician)
        {
            Musician = musician;
            return this.SetAuthor(musician.Name);
        }

        public void ChangeChartPosition(int chartPosition) 
        {
            if (chartPosition > 0 && chartPosition <= 100)
            {
                ChartPosition = chartPosition;
            }
        }

        public void ChangeRating(double value)
        {
            if (value >= 0.0 && value <= 10.0)
            {
                Rating = value;
            }
        }

        public string CopyImage(string imagePath, string imageStoringPath)
        {
            var imageName = new StringBuilder()
                        .Append('q')
                        .Append(Song.GetHashedName(Name))
                        .Append('q')
                        .Append(Path.GetExtension(imagePath))
                        .ToString();

            var path = Path.Combine(
                imageStoringPath,
                imageName);

            File.Copy(imagePath, path);

            return imageName;
        }

        public string GetImagePath(string imageStoringPath, string defaultName)
        {
            var name = new StringBuilder()
                .Append('q')
                .Append(Song.GetHashedName(Name))
                .Append('q')
                .Append(".jpg")
                .ToString();

            var path = Path.Combine(imageStoringPath, name);

            return File.Exists(path) ? name : defaultName;
        }
    }
}
    