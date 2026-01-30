using System.Runtime.InteropServices;

namespace ChessLib.Utils;

public static class GeneralUtils
{
    public static bool IsLinux()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}