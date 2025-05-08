using System.Globalization;

namespace Bogoware.Utils;

using static CultureInfo;

/// <summary>
/// Provides helper extension methods for converting various types to their string representation
/// using the invariant culture formatting.
/// </summary>
/// <remarks>
/// Source code is available at <a href="https://github.com/bogoware/Utils">Bogoware.Utils</a>.
/// </remarks>
public static class ToStringHelpers
{
    public static string ToStringInvariant(this byte obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this short obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this int obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this long obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this float obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this double obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this DateOnly obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this DateTime obj) => obj.ToString(InvariantCulture);
    public static string ToStringInvariant(this DateTimeOffset obj) => obj.ToString(InvariantCulture);
}