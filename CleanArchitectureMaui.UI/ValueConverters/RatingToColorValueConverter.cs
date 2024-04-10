using System.Globalization;

namespace CleanArchitectureMaui.UI.ValueConverters
{
    public class RatingToColorValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is null || (double)value < 9.0 ? 
                Colors.WhiteSmoke : Colors.LightPink;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
