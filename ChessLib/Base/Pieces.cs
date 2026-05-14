namespace ChessLib.Base;

/// <summary>
/// Byte constants representing pieces
/// </summary>
public static class Pieces
{
    // objective values: contains piece type and color
    
    public const byte Empty = 0;

    /// <summary>
    /// White pawn: 0010 = 2
    /// </summary>
    public const byte WPawn = 2;
    /// <summary>
    /// black pawn: 0011 = 3
    /// </summary>
    public const byte BPawn = 3;
    /// <summary>
    /// White knight: 0100 = 4
    /// </summary>
    public const byte WKnight = 4;
    /// <summary>
    /// Black knight: 0101 = 5
    /// </summary>
    public const byte BKnight = 5;
    /// <summary>
    /// White bishop: 0110 = 6
    /// </summary>
    public const byte WBishop = 6;
    /// <summary>
    /// Black bishop: 0111 = 7
    /// </summary>
    public const byte BBishop = 7;
    /// <summary>
    /// White rook: 1000 = 8
    /// </summary>
    public const byte WRook = 8;
    /// <summary>
    /// Black rook: 1001 = 9
    /// </summary>
    public const byte BRook = 9;
    /// <summary>
    /// White queen: 1010 = 10
    /// </summary>
    public const byte WQueen = 10;
    /// <summary>
    /// Black queen: 1011 = 11
    /// </summary>
    public const byte BQueen = 11;
    /// <summary>
    /// White king: 1100 = 12
    /// </summary>
    public const byte WKing = 12;
    /// <summary>
    /// Black king: 0010 = 13
    /// </summary>
    public const byte BKing = 13;

    // type values: irrespective of color
    
    /// <summary>
    /// Pawn (type): 001 = 1
    /// </summary>
    public const byte Pawn = 0b001;
    /// <summary>
    /// Knight (type): 010 = 2
    /// </summary>
    public const byte Knight = 0b010;
    /// <summary>
    /// Bishop (type): 011 = 3
    /// </summary>
    public const byte Bishop = 0b011;
    /// <summary>
    /// Rook (type): 100 = 4
    /// </summary>
    public const byte Rook = 0b100;
    /// <summary>
    /// Queen (type): 101 = 5
    /// </summary>
    public const byte Queen = 0b101;
    /// <summary>
    /// King (type): 110 = 6
    /// </summary>
    public const byte King = 0b110;
}