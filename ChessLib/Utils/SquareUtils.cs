namespace ChessLib.Utils;

public static class SquareUtils
{
    /// <summary>
    /// Returns the given index as a file-rank tuple
    /// </summary>
    public static (int file, int rank) AsSquare(this int index)
    {
        return (index / 8, index % 8);
    }

    /// <summary>
    /// Returns the given tuple as an index
    /// </summary>
    public static int AsIndex(this (int file, int rank) square)
    {
        return square.file + square.rank * 8;
    }
}