namespace ChessLib.API.Display.Formatting;

public class PieceFormat(char[] pieces, ConsoleColor light = ConsoleColor.DarkGray, ConsoleColor dark = ConsoleColor.Black)
{
    public readonly ConsoleColor Light = light;
    public readonly ConsoleColor Dark = dark;
    
    public char FormatPiece(byte piece)
    {
        return pieces[piece];
    }

    public ConsoleColor GetColorAt(int index)
    {
        int colorIndex = index + (index % 8);
        
        return colorIndex % 2 == 0
            ? Dark
            : Light;
    }
}