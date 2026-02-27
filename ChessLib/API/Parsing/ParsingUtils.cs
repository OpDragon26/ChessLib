using ChessLib.API.Display;

namespace ChessLib.API.Parsing;

public static class ParsingUtils
{
    public static (int file, int rank) ParseSquare(this string square)
    {
        int file = square[0].GetFile();
        int rank = square[1].GetRank();

        return (file, rank);
    }
}