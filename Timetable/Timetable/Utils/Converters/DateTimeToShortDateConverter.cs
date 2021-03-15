using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timetable.Utils.Converters
{
    public class DateTimeToShortDateConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;

			return ((DateTime)value).ToString("dd.MM.yyyy");
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DateTime.Now.ToString("dd.MM.yyyy");
		}
	}
}
