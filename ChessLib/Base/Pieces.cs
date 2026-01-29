namespace ChessLib.Base;

public static class Pieces
{
    public const byte Empty = 0;

    public const byte WPawn = 2; // 0010
    public const byte BPawn = 3; // 0011
    public const byte WKnight = 4; // 0100
    public const byte BKnight = 5; // 0101
    public const byte WBishop = 6; // 0110
    public const byte BBishop = 7; // 0111
    public const byte WRook = 8; // 1000
    public const byte BRook = 9; // 1001
    public const byte WQueen = 10; // 1010
    public const byte BQueen = 11; // 1011
    public const byte WKing = 12; // 1100
    public const byte BKing = 13; // 1101

    public const byte Pawn = 0b001;
    public const byte Knight = 0b010;
    public const byte Bishop = 0b011;
    public const byte Rook = 0b100;
    public const byte Queen = 0b101;
    public const byte King = 0b110;
}