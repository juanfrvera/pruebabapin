using Core.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    /// <summary>
    /// Extension methods for String class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Throws an ArgumentNullException if the string is null, or an ArgumentException if its empty.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="parameterName">Name of the parameter that's being checked.</param>
        public static void ThrowIfNullOrEmpty(this string value, string parameterName)
        {
            StringUtils.ThrowIfNullOrEmpty(value, parameterName);
        }

        /// <summary>
        /// Throws an ArgumentNullException if the string is null, or an ArgumentException if its empty.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="parameterName">Name of the parameter that's being checked.</param>
        /// <param name="message">Custom message for the exception.</param>
        public static void ThrowIfNullOrEmpty(this string value, string parameterName, string message)
        {
            StringUtils.ThrowIfNullOrEmpty(value, parameterName, message);
        }

        /// <summary>
        /// Applies string.Format using this string as format and InvariantCulture.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        /// <returns>The formatted string using InvariantCulture</returns>
        public static string InvariantFormat(this string format, params object[] args)
        {
            return StringUtils.InvariantFormat(format, args);
        }

        /// <summary>
        /// Deletes all the characters from this string beginning at a specified position and continuing through the last position.
        /// If the string Length is equal or smaller than the provided startIndex, the original string is returned.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>A shortened string.</returns>
        public static string SafeRemove(this string text, int startIndex)
        {
            return StringUtils.SafeRemove(text, startIndex);
        }

        /// <summary>
        /// Trims the given string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>A trimmed string.</returns>
        public static string SafeTrim(this string text)
        {
            return StringUtils.SafeTrim(text);
        }

        /// <summary>
        /// Determines whether the specified string contains any of the given substrings.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="substrings">The substrings.</param>
        /// <returns>
        ///     <c>true</c> if the specified list contains any of the given substrings; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAny(this string text, IEnumerable<string> substrings)
        {
            return StringUtils.ContainsAny(text, substrings);
        }

        /// <summary>
        /// Determines whether the specified text is null or empty.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     <c>true</c> if the specified text is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Returns null if the specified string is empty, otherwise, returns the specified string.
        /// </summary>
        /// <param name="text">The specified string.</param>
        /// <returns>Returns null if the string is empty, otherwise, returns the specified string.</returns>
        public static string EmptyToNull(this string text)
        {
            if (!string.IsNullOrEmpty(text)) return text;
            return null;
        }

        /// <summary>
        /// Joins the given list of strings with the specified separator.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="values">The values.</param>
        /// <returns>A joined string by the separator.</returns>
        public static string Join(this string separator, IEnumerable<string> values)
        {
            if (values == null) return string.Empty;

            separator = separator ?? string.Empty;
            return string.Join(separator, values.ToArray());
        }

        /// <summary>
        /// Split a string by case.
        /// </summary>
        /// <param name="text">A string.</param>
        /// <returns>A list of substring split by case.</returns>
        public static IList<string> CaseSplit(this string text)
        {
            return StringUtils.CaseSplit(text);
        }

        /// <summary>
        /// Separates a string by spaces.
        /// </summary>
        /// <param name="text">A string.</param>
        /// <returns>A string with spaces.</returns>
        public static string CaseSeparate(this string text)
        {
            return StringUtils.CaseSeparate(text);
        }

        /// <summary>
        /// Separates a string using the provided separator.
        /// </summary>
        /// <param name="text">A string.</param>
        /// <param name="separator">A separator.</param>
        /// <returns>A string with the provided separator.</returns>
        public static string CaseSeparate(this string text, string separator)
        {
            return StringUtils.CaseSeparate(text, separator);
        }

        /// <summary>
        /// Searches the given string for the given value and returns it if found.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="value">The search value.</param>
        /// <returns>The found string.</returns>
        public static string SubstringSearch(this string text, string value)
        {
            return StringUtils.SubstringSearch(text, value);
        }

        /// <summary>
        /// Searches a substring in a string ignoring some chars.
        /// </summary>
        /// <param name="text">The text to look into.</param>
        /// <param name="value">The search value.</param>
        /// <param name="charsToIgnore">The characters to ignore.</param>
        /// <returns>The matching string value or string.Empty.</returns>
        public static string SubstringSearch(this string text, string value, char[] charsToIgnore)
        {
            return StringUtils.SubstringSearch(text, value, charsToIgnore);
        }

        /// <summary>
        /// Capitalizes the specified string.
        /// </summary>
        /// <param name="text">The text to capitalize.</param>
        /// <returns>The capitalized string.</returns>
        public static string Capitalize(this string text)
        {
            return StringUtils.Capitalize(text);
        }

        /// <summary>
        /// Add a slash ("/") at the end of the string if it doesn't have one yet.
        /// </summary>
        /// <param name="url">The URL without final slash probably.</param>
        /// <returns>The URL with a slash at the end or null.</returns>
        public static string AddFowardSlashIfRequired(this string url)
        {
            return StringUtils.AddFowardSlashIfRequired(url);
        }

        /// <summary>
        /// Remove the last slash ("/") at the end of the string if it has one.
        /// </summary>
        /// <param name="url">The URL with final slash probably.</param>
        /// <returns>The URL without a slash at the end or null.</returns>
        public static string RemoveFowardSlashIfRequired(this string url)
        {
            return StringUtils.RemoveFowardSlashIfRequired(url);
        }
    }
}
