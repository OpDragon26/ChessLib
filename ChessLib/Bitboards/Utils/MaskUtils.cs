namespace ChessLib.Bitboards.Utils;

public static class MaskUtils
{
    public const ulong File = 0x101010101010101;
    public const ulong Rank = 0xFF;
    public const ulong UpDiagonal = 0x102040810204080;
    public const ulong DownDiagonal = 0x8040201008040201;
    
    /// <summary>
    /// Returns a bitboard with all the bits for the given file switched on
    /// </summary>
    public static ulong GetFile(int file)
    {
        return File << file * 8;
    }

    /// <summary>
    /// Returns a bitboard with all the bits for the given rank switched on
    /// </summary>
    public static ulong GetRank(int rank)
    {
        return Rank << rank;
    }

    /// <summary>
    /// Returns a bitboard of the upwards (bottom left to top right) diagonal line which goes through the given square
    /// </summary>
    public static ulong GetUD((int file, int rank) square)
    {
        int push = (square.rank - square.file) * 8;
        return push >= 0 ? UpDiagonal >> push : UpDiagonal << -push;
    }

    /// <summary>
    /// Returns a bitboard of the downwards (top left to bottom right) diagonal line which goes through the given square
    /// </summary>
    public static ulong GetDD((int file, int rank) square)
    {
        int push = (square.rank + square.file - 7) * 8;
        return push >= 0 ? DownDiagonal >> push : DownDiagonal << -push;
    }
}