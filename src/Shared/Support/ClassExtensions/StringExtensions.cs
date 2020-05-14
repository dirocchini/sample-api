using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Shared.Support.ClassExtensions
{
    public static class StringExtensions
    {
        public static T DynamicConvert<T>(this string value)
        {
            try
            {
                if (typeof(T) == typeof(bool))
                    return (T)ParseToBool(value);
                else if (typeof(T) == typeof(DateTime))
                    return (T)ParseToDateTime(value);
                else if (typeof(T) == typeof(decimal))
                    return (T)ParseToDecimal(value);
                else if (typeof(T) == typeof(TimeSpan))
                    return (T)ParseToTimeSpan(value);

                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                    return (T)converter.ConvertFromString(value);

                return default;
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }

        private static object ParseToBool(this string value)
        {
            value = value.ToLower().Trim();

            if (value == "y" || value == "s" ||
                value == "yes" || value == "sim" ||
                value == "true" || value == "1")
                return true;

            return false;
        }

        private static object ParseToDateTime(this string value)
        {
            string[] formats = { "dd/MM/yyyy", "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss:ffffff" };
            return DateTime.ParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        private static object ParseToDecimal(string value)
        {
            return Convert.ToDecimal(value, new CultureInfo("en-US"));
        }

        private static object ParseToTimeSpan(string value)
        {
            TimeSpan.TryParse(value, out TimeSpan timeSpan);

            return timeSpan;
        }
    }
}
