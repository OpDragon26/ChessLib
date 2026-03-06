namespace ChessLib.Utils;

public static class SquareUtils
{
    /// <summary>
    /// Returns the given index as a file-rank tuple
    /// </summary>
    public static (int file, int rank) AsSquare(this int index)
    {
        return (index % 8, index / 8);
    }

    /// <summary>
    /// Returns the given tuple as an index
    /// </summary>
    public static int AsIndex(this (int file, int rank) square)
    {
        return square.file + square.rank * 8;
    }

    /// <summary>
    /// Offsets the given tuple in a set direction by a set amount, then returns the result
    /// </summary>
    public static (int file, int rank) OffsetBy(this (int file, int rank) square, (int file, int rank) offset, int amount = 1)
    {
        int file = square.file + offset.file * amount;
        int rank = square.rank + offset.rank * amount;
        return (file, rank);
    }

    /// <summary>
    /// Checks whether the given square is outside the board
    /// </summary>
    public static bool OutOfBounds(this (int file, int rank) square)
    {
        return square.file < 0 || square.file > 7
            || square.rank < 0 || square.rank > 7;
    }
}