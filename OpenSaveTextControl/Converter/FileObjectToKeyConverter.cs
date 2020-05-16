

namespace OpenSave.Wpf
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    using Contracts;

    public class FileObjectToKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (value as SelectionChangedEventArgs).AddedItems.Cast<IPath>().FirstOrDefault()?.Path;
            if (path != null)
            {
                return System.IO.Path.GetFileNameWithoutExtension(path);
            }

            return DependencyProperty.UnsetValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
