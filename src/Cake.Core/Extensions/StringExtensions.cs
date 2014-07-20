﻿using System;

// ReSharper disable once CheckNamespace
namespace Cake.Core
{
    /// <summary>
    /// Contains extension methods for <see cref="String"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Quotes the specified <see cref="String"/>.
        /// </summary>
        /// <param name="value">The string to quote.</param>
        /// <returns>A quoted string.</returns>
        public static string Quote(this string value)
        {
            if (!IsQuoted(value))
            {
                value = string.Concat("\"", value, "\"");
            }
            return value;
        }

        /// <summary>
        /// Unquotes the specified <see cref="String"/>.
        /// </summary>
        /// <param name="value">The string to unquote.</param>
        /// <returns>An unquoted string.</returns>
        public static string UnQuote(this string value)
        {
            if (IsQuoted(value))
            {
                value = value.Trim('"');                
            }
            return value;
        }

        private static bool IsQuoted(this string value)
        {
            return value.StartsWith("\"", StringComparison.OrdinalIgnoreCase)
                   && value.EndsWith("\"", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Splits the <see cref="String"/> into lines.
        /// </summary>
        /// <param name="content">The string to split.</param>
        /// <returns>The lines making up the provided string.</returns>
        public static string[] SplitLines(this string content)
        {
            content = NormalizeLineEndings(content);
            return content.Split(new[] { "\r\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Normalizes the line endings in a <see cref="String"/>.
        /// </summary>
        /// <param name="value">The string to normalize line endings in.</param>
        /// <returns>A <see cref="String"/> with normalized line endings.</returns>
        public static string NormalizeLineEndings(this string value)
        {
            value = value.Replace("\r\n", "\n");
            value = value.Replace("\r", string.Empty);
            return value.Replace("\n", "\r\n");
        }
    }
}