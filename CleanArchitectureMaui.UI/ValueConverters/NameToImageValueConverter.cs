using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CleanArchitectureMaui.UI.ValueConverters
{
    public class NameToImageValueConverter : IValueConverter
    {
        private readonly string _imageStoringPath 
            = "C:\\Users\\ac1dl\\source\\repos\\CleanArchitectureMaui\\CleanArchitectureMaui.UI\\Resources\\Images";
        private readonly string _defaultName
            = "default.jpg";

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var song = (Song)value!;

            return song is null ? null : song.GetImagePath(_imageStoringPath, _defaultName);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
