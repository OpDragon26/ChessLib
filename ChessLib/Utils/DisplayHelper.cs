namespace ChessLib.Utils;

public static class DisplayHelper
{
    /// <summary>
    /// Returns the given ulong as a binary string
    /// </summary>
    public static string ToBinary(this ulong n, bool includePrefix = true)
    {
        return (includePrefix ? "0b" : "") + Convert.ToString((long)n, 2).PadLeft(64, '0');
    }

    /// <summary>
    /// Returns the given ulong as a hexadecimal (base 16) string
    /// </summary>
    public static string ToHex(this ulong n, bool includePrefix = true)
    {
        return (includePrefix ? "0x" : "") + Convert.ToString((long)n, 16);
    }

    /// <summary>
    /// Returns a string of an enumerable using the ToString method of the elements
    /// </summary>
    public static string ToArrayString<T>(this IEnumerable<T> list)
    {
        return "[" + string.Join(", ", list) + "]";
    }
    
    /// <summary>
    /// Returns a string of an enumerable using the given method to convert the elements into a string
    /// </summary>
    public static string ToArrayString<T>(this IEnumerable<T> list, Func<T, string> selector)
    {
        return "[" + string.Join(", ", list.Select(selector)) + "]";
    }
}