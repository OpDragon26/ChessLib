using ChessLib.API.Generic;

namespace ChessLib.API.Display.Formatting;

/// <summary>
/// Specifies how to convert a board into a string
/// </summary>
public class PieceFormat(char[] pieces, ConsoleColor light = ConsoleColor.DarkGray, ConsoleColor dark = ConsoleColor.Black, ConsoleColor piece = ConsoleColor.White)
{
    public readonly ConsoleColor Light = light;
    public readonly ConsoleColor Dark = dark;
    public readonly ConsoleColor Piece = piece;
    
    /// <summary>
    /// Returns the corresponding piece char
    /// </summary>
    public char FormatPiece(byte piece)
    {
        return 
            pieces[piece];
    }

    public byte ParsePiece(char piece)
    {
        return (byte)Array.IndexOf(pieces, (object)piece);
    }

    /// <summary>
    /// Returns the color of the board at the given square
    /// </summary>
    public ConsoleColor GetColorAt(int index)
    {
        int colorIndex = index + (index % 8);
        
        return colorIndex % 2 == 0
            ? Dark
            : Light;
    }

    /// <summary>
    /// Returns the color of the board at the given square
    /// </summary>
    public ConsoleColor GetColorAt(Coordinate coordinate)
    {
        return GetColorAt(coordinate.AsIndex());
    }
}