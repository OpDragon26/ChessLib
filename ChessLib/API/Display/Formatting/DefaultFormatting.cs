using System.Runtime.InteropServices;

namespace ChessLib.API.Display.Formatting;

public static class DefaultFormatting
{
    public static readonly PieceFormat Unicode = new([' ', '?', '♟', '♙', '♞', '♘', '♝', '♗', '♜', '♖', '♛', '♕', '♚', '♔']);
    public static readonly PieceFormat ASCII = new([' ', '?', 'P', 'p', 'N', 'n', 'B', 'b', 'R', 'r', 'Q', 'q', 'K', 'k']);

    public static PieceFormat GetOSDefault()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            ? Unicode
            : ASCII;
    }
}