namespace ChessLib.Base;

public static class PieceUtils
{
    public static byte Type(this byte piece)
    {
        return (byte)(piece >> 1);
    }

    public static bool IsType(this byte piece, byte type)
    {
        return piece.Type() == type;
    }

    public static int Color(this byte piece)
    {
        return piece & 1;
    }

    public static byte AsColor(this byte piece, int color)
    {
        return (byte)((piece << 1) | color);
    }

    public static byte SetColor(this byte piece, int color)
    {
        return (byte)((piece & 0b1110) | color);
    }
}