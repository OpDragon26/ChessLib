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
}