using static ChessLib.Utils.GeneralUtils;

namespace ChessLib.API.Display.Formatting;

public static class DefaultFormatting
{
    public static readonly BitFormat Bitboard = new('#', '.');
    public static readonly BitFormat Binary = new('1', '0');
    
    public static readonly PieceFormat Unicode = new([' ', '?', '♟', '♙', '♞', '♘', '♝', '♗', '♜', '♖', '♛', '♕', '♚', '♔']);
    public static readonly PieceFormat ASCII = new([' ', '?', 'P', 'p', 'N', 'n', 'B', 'b', 'R', 'r', 'Q', 'q', 'K', 'k']);
    public static readonly PieceFormat UnicodeLight = new(
        [' ', '?', '♙', '♟', '♘', '♞', '♗', '♝', '♖', '♜', '♕', '♛', '♔', '♚'],
        ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Black
        );
    public static readonly PieceFormat ASCIILight = new(
        [' ', '?', 'P', 'p', 'N', 'n', 'B', 'b', 'R', 'r', 'Q', 'q', 'K', 'k'],
        ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Black
        );

    /// <summary>
    /// Returns the default formatting for the current OS's terminal
    /// </summary>
    public static PieceFormat GetOSDefault()
    {
        return IsLinux()
            ? Unicode
            : ASCII;
    }

    /// <summary>
    /// Returns the default light formatting for the current OS's terminal
    /// </summary>
    public static PieceFormat GetOSLight()
    {
        return IsLinux()
            ? UnicodeLight
            : ASCIILight;
    }
}