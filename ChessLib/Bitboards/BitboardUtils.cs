namespace ChessLib.Bitboards;

/*
 * Bitboards store whether a square is occupied by a certain piece
 * the least significant bit represents a1
 */

public static class BitboardUtils
{
    public static ulong AsBitboard(this int index)
    {
        return 1ul << index;
    }

    public static bool SharesBits(this ulong bitboard, ulong other)
    {
        return (bitboard & other) != 0;
    }
    
    public static bool Occupied(this ulong bitboard, int index)
    {
        return bitboard.SharesBits(index.AsBitboard());
    }

    public static void EnableBit(this ref ulong bitboard, int index)
    {
        bitboard |= index.AsBitboard();
    }

    public static void DisableBit(this ref ulong bitboard, int index)
    {
        bitboard &= ~index.AsBitboard();
    }
}