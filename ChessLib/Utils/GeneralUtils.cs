using System.Runtime.InteropServices;

namespace ChessLib.Utils;

public static class GeneralUtils
{
    private static readonly Random random = new();
    
    public static bool IsLinux()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }

    public static ulong Random(ulong min = 0, ulong max = ulong.MaxValue)
    {
        ulong rand = (ulong)random.NextInt64();
        return rand % (max - min) + min;
    }
}