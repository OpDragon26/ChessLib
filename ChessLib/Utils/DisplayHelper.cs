namespace ChessLib.Utils;

public static class DisplayHelper
{
    public static string ToBinary(this ulong n)
    {
        return Convert.ToString((long)n, 2).PadLeft(64, '0');
    }

    public static string ToHex(this ulong n)
    {
        return "0b" + Convert.ToString((long)n, 16);
    }

    public static string ToArrayString<T>(this IEnumerable<T> list)
    {
        return "[" + string.Join(" ", list) + "]";
    }
}