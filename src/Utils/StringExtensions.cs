using System.Diagnostics.CodeAnalysis;

namespace Bogoware.Utils;

/// <summary>
/// Provides extension methods for string operations.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Determines whether the specified string is null or an empty string.
    /// </summary>
    /// <param name="value">The string to check for null or empty.</param>
    /// <returns>
    /// true if the string is null or an empty string (""); otherwise, false.
    /// </returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) 
        => string.IsNullOrEmpty(value);

    /// <summary>
    /// Determines whether the specified string is null, an empty string, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to check for null, empty, or only white-space characters.</param>
    /// <returns>
    /// true if the string is null, an empty string (""), or consists only of white-space characters; otherwise, false.
    /// </returns>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) 
        => string.IsNullOrWhiteSpace(value);
}