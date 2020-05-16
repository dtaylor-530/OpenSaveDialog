

namespace OpenSave.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;

    public class TextObjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            string param = parameter as string;
            var source = (value as TextChangedEventArgs).Source;

            string text = null;
            if (source is TextBox box)
            {
                text = box.Text;
            }
            else if (source is RichTextBox rbox)
            {
                var doc = rbox.Document;
                TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
                text = range.Text;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
            ///Todo fix this
            return null;//new ObjectChange { Property = param, Value = text };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
            //string param = parameter as string;
            //var doc = ((value as TextChangedEventArgs).Source as RichTextBox).Document;

            //TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);

            //return new ObjectChange { Property = param, Value = range.Text };
        }
    }
}
