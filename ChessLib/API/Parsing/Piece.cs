using ChessLib.API.Display.Formatting;

namespace ChessLib.API.Parsing;

public static class Piece
{
    /// <summary>
    /// Finds the byte code of the piece based on the given formatting
    /// </summary>
    public static byte ParsePiece(char piece, PieceFormat format)
    {
        return format.ParsePiece(piece);
    }

    /// <summary>
    /// Finds the byte code of the piece based on algebraic formatting
    /// </summary>
    public static byte ParsePiece(char piece)
    {
        return DefaultFormatting.ASCII.ParsePiece(piece);
    }
}