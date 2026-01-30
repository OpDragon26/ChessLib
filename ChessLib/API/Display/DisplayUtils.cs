using ChessLib.Utils;

namespace ChessLib.API.Display;

public static class DisplayUtils
{
    private static readonly char[] Files = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];
    private static readonly char[] Ranks = ['1', '2', '3', '4', '5', '6', '7', '8'];
    
    public static string ToAlgebraic(this (int file, int rank) square)
    {
        return $"{square.file.AsFile()}{square.rank.AsRank()}";
    }
    
    public static string ToAlgebraic(this int index)
    {
        return index.AsSquare().ToAlgebraic();
    }

    public static char AsFile(this int file)
    {
        return Files[file];
    }

    public static char AsRank(this int rank)
    {
        return Ranks[rank];
    }
}