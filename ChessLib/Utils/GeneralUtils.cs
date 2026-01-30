namespace ChessLib.Utils;

public static class GeneralUtils
{
    public static (int file, int rank) AsSquare(this int index)
    {
        return (index / 8, index % 8);
    }

    public static int AsIndex(this (int file, int rank) square)
    {
        return square.file + square.rank * 8;
    }
}