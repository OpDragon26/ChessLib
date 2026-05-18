using System.Runtime.InteropServices;

namespace ChessLib.Utils;

public static class GeneralUtils
{
    private static readonly Random random = new();
    
    /// <summary>
    /// Returns whether the OS is Linux (and thus likely can display Unicode piece characters in the default terminal)
    /// </summary>
    public static bool IsLinux()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }

    /// <summary>
    /// Returns a random ulong between min and max
    /// </summary>
    public static ulong Random(ulong min = 0, ulong max = ulong.MaxValue)
    {
        ulong rand = (ulong)random.NextInt64();
        return rand % (max - min) + min;
    }

    /// <summary>
    /// Returns index of value in array
    /// </summary>
    public static int IndexOf<T>(this IEnumerable<T> enumerable, T value) where T : IEquatable<T>
    {
        int indexOf = -1;
        int index = 0;
        foreach (T item in enumerable)
        {
            if (item.Equals(value))
                indexOf = index;
            index++;
        }
        return indexOf;
    }
}