using static System.Globalization.CultureInfo;

namespace Bogoware.Utils;

/// <summary>
/// Provides extension methods for parsing string values into various types using the invariant culture.
/// </summary>
public static class StringParseHelpers
{
    public static byte ParseToByteInvariant(this string obj) => byte.Parse(obj, InvariantCulture);
    public static short ParseToShortInvariant(this string obj) => short.Parse(obj, InvariantCulture);
    public static int ParseToIntInvariant(this string obj) => int.Parse(obj, InvariantCulture);
    public static long ParseToLongInvariant(this string obj) => long.Parse(obj, InvariantCulture);
    public static float ParseToFloatInvariant(this string obj) => float.Parse(obj, InvariantCulture);
    public static double ParseToDoubleInvariant(this string obj) => double.Parse(obj, InvariantCulture);
    public static DateOnly ParseToDateOnlyInvariant(this string obj) => DateOnly.Parse(obj, InvariantCulture);
    public static DateTime ParseToDateTimeInvariant(this string obj) => DateTime.Parse(obj, InvariantCulture);
    public static DateTimeOffset ParseToDateTimeOffsetInvariant(this string obj) => DateTimeOffset.Parse(obj, InvariantCulture);
}