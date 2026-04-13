using ChessLib.Utils;

namespace ChessLib.API.Display;

public static class DisplayUtils
{
    private static readonly char[] Files = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];
    private static readonly char[] Ranks = ['1', '2', '3', '4', '5', '6', '7', '8'];
    
    /// <summary>
    /// Converts a file-rank tuple into algebraic notation
    /// </summary>
    public static string ToAlgebraic(this (int file, int rank) square)
    {
        return $"{square.file.AsFile()}{square.rank.AsRank()}";
    }
    
    /// <summary>
    /// Converts an index into algebraic notation
    /// </summary>
    public static string ToAlgebraic(this int index)
    {
        return index.AsSquare().ToAlgebraic();
    }
    
    /// <summary>
    /// Returns the file char for a given file
    /// </summary>
    public static char AsFile(this int file)
    {
        return Files[file];
    }
    
    /// <summary>
    /// Returns the rank char for a given file
    /// </summary>
    public static char AsRank(this int rank)
    {
        return Ranks[rank];
    }

    /// <summary>
    /// Returns the file index of a char
    /// </summary>
    public static int GetFile(this char file)
    {
        return file - 'a';
    }

    /// <summary>
    /// Returns the rank index of a char
    /// </summary>
    public static int GetRank(this char rank)
    {
        return rank - '1';
    }
}