using System.Security.Cryptography;
using System.Text;

namespace CleanArchitectureMaui.Domain.Entities
{
    public class Musician : Entity
    {
        private readonly List<Song> _songs = [];
        public string Name { get; private set; } = string.Empty;
        public int MonthListeners { get; private set; } = 0;
        public IReadOnlyList<Song> Songs => _songs.AsReadOnly();
        public string ImagePath { get; private set; } = string.Empty;
        
        public Musician() { }

        public Musician(string name, int monthListeners)
        {
            Id = BitConverter.ToInt32
            (
                SHA256.HashData(Encoding.UTF8.GetBytes(name))
            );
            Name = name;
            MonthListeners = monthListeners;
            _songs = [];
        }

        public void ChangeMonthListenersAmount(int amount) 
        {
            if (amount > 0)
            {
                MonthListeners = amount;
            }
        }

        public static string GetHashedName(string name)
        {
            return BitConverter.ToString(
                SHA256.HashData(Encoding.UTF8.GetBytes(name)))
                    .Replace("-", "")
                    .ToLower();
        }

        public string CopyImage(string imagePath, string imageStoringPath)
        {
            var imageName = new StringBuilder()
                        .Append('a')
                        .Append(Musician.GetHashedName(Name))
                        .Append('a')
                        .Append(Path.GetExtension(imagePath))
                        .ToString();

            var path = Path.Combine(
                imageStoringPath,
                imageName);

            File.Copy(imagePath, path);
            ImagePath = imageName;

            return imageName;
        }

        public static bool AreValidFields(string? name, int? monthListeners)
            => !string.IsNullOrEmpty(name) &&
                monthListeners is not null &&
                monthListeners > 0;

        public Musician AddSong(Song song) 
        {
            if (!_songs.Contains(song))
            {
                _songs.Add(song);
            }

            return this;
        }

        public void RemoveSong(Song song) 
        {
            _songs.Remove(song);
        }

        public void AddProfilePicture(string path)
        {
            ImagePath = path;
        }
    }
}
