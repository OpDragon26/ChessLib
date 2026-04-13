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
}