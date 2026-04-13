namespace ChessLib.Base.Utils;

public static class PieceUtils
{
    // check Pieces.cs for explanation
    
    /// <summary>
    /// Returns the type based on objective value
    /// </summary>
    public static byte Type(this byte piece)
    {
        return (byte)(piece >> 1);
    }

    /// <summary>
    /// Checks whether an objective value is of a given type
    /// </summary>
    public static bool IsType(this byte piece, byte type)
    {
        return piece.Type() == type;
    }

    /// <summary>
    /// Returns the color of the piece
    /// </summary>
    public static int Color(this byte piece)
    {
        return piece & 1;
    }

    /// <summary>
    /// Returns a piece of a given color given a type
    /// </summary>
    public static byte AsColor(this byte type, int color)
    {
        return (byte)((type << 1) | color);
    }

    /// <summary>
    /// Returns a piece of a given color given an objective value
    /// </summary>
    public static byte SetColor(this byte piece, int color)
    {
        return (byte)((piece & 0b1110) | color);
    }
}