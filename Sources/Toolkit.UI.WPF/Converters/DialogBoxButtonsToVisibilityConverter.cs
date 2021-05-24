using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Toolkit.Contracts;
using Toolkit.UI.WPF.Controls;

namespace Toolkit.UI.WPF.Converters
{
    internal class DialogBoxButtonsToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Contract.Is<InvalidCastException>((value as DialogBoxButtons?) != null);
            var arg = Contract.StringFilled<InvalidCastException>((string)parameter);

            if (value is DialogBoxButtons button)
            {
                var types = Enum.GetValues(typeof(DialogBoxButtons));

                foreach (DialogBoxButtons item in types)
                {
                    if ((button & item) == item)
                    {
                        switch (item)
                        {
                            case DialogBoxButtons.Primary:
                                if (arg == "Primary") return Visibility.Visible;
                                break;
                            case DialogBoxButtons.Secondary:
                                if (arg == "Secondary") return Visibility.Visible;
                                break;
                            case DialogBoxButtons.Close:
                                if (arg == "Close") return Visibility.Visible;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}