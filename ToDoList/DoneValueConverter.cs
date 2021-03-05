using System;
using System.Globalization;
using System.Windows.Data;

namespace ToDoList
{
	public class DoneValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) return "";
			var isDone = (bool)value;
			return isDone ? "Done" : "Not Done";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var isDone = value?.ToString();
			return isDone == "Done";
		}
	}
}
