using System.Text.RegularExpressions;

namespace ATDS.API.Extenstion
{
    public static class StringExtension
    {
        public static string ToSnakeCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return Regex.Match(text, "^_+")?.ToString() + Regex.Replace(text, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static string ToCamelCase(this string text)
        {
            return (string.IsNullOrWhiteSpace(text) || text.Length < 2) ? text : (char.ToLowerInvariant(text[0]) + text.Substring(1));
        }
    }
}
