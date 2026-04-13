using ChessLib.API.Display;

namespace ChessLib.API.Parsing;

public static class ParsingUtils
{
    /// <summary>
    /// Parse algebraic square notation to a file-rank tuple
    /// </summary>
    /// <example>
    /// "e4" -> (4, 3)
    /// </example>
    public static (int file, int rank) ParseSquare(this string square)
    {
        int file = square[0].GetFile();
        int rank = square[1].GetRank();

        return (file, rank);
    }
}