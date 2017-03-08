using System;

namespace api.Extensions
{
    public static class StringExtension
    {
        public static string ToTitleCase(this string input)
        {
            var items = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string response = string.Empty;
            for (int i = 0; i <= items.Length - 1; i++)
            {
                items[i] = $"{items[i].Substring(0, 1).ToUpper()}{items[i].Substring(1)}";
            }
            return string.Join(" ", items);
        }

        public static string ToLongDateFormat(this string input)
        {
            var isDate = DateTime.TryParse(input, out DateTime parsedDate);
            if (!isDate)
                return string.Empty;

            return parsedDate.ToString("dddd dd MMMM yyyy");
        }
    }
}
