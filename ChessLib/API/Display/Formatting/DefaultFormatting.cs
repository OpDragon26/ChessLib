using static ChessLib.Utils.GeneralUtils;

namespace ChessLib.API.Display.Formatting;

public static class DefaultFormatting
{
    public static readonly PieceFormat Unicode = new([' ', '?', '♟', '♙', '♞', '♘', '♝', '♗', '♜', '♖', '♛', '♕', '♚', '♔']);
    public static readonly PieceFormat ASCII = new([' ', '?', 'P', 'p', 'N', 'n', 'B', 'b', 'R', 'r', 'Q', 'q', 'K', 'k']);
    public static readonly PieceFormat UnicodeLight = new(
        [' ', '?', '♙', '♟', '♘', '♞', '♗', '♝', '♖', '♜', '♕', '♛', '♔', '♚'],
        ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.Black
        );
    public static readonly PieceFormat ASCIILight = new(
        [' ', '?', 'P', 'p', 'N', 'n', 'B', 'b', 'R', 'r', 'Q', 'q', 'K', 'k'],
        ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.Black
        );

    public static PieceFormat GetOSDefault()
    {
        return IsLinux()
            ? Unicode
            : ASCII;
    }

    public static PieceFormat GetOSLight()
    {
        return IsLinux()
            ? UnicodeLight
            : ASCIILight;
    }
}