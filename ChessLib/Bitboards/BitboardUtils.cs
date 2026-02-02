namespace ChessLib.Bitboards;

/*
 * Bitboards store whether a square is occupied by a certain piece
 * the least significant bit represents a1
 */

public static class BitboardUtils
{
    /// <summary>
    /// Returns the given index represented as a bitboard
    /// </summary>
    public static ulong ToBitboard(this int index)
    {
        return 1ul << index;
    }

    /// <summary>
    /// Returns whether the two bitboards have shared bits
    /// </summary>
    public static bool SharesBits(this ulong bitboard, ulong other)
    {
        return (bitboard & other) != 0;
    }
    
    /// <summary>
    /// Returns whether the given index is turned to 1 on the bitboard
    /// </summary>
    public static bool Occupied(this ulong bitboard, int index)
    {
        return bitboard.SharesBits(index.ToBitboard());
    }

    /// <summary>
    /// Turns the given bit to 1 on the bitboard
    /// </summary>
    public static void EnableBit(this ref ulong bitboard, int index)
    {
        bitboard |= index.ToBitboard();
    }

    /// <summary>
    /// Turns the given bit to 0 on the bitboard
    /// </summary>
    public static void DisableBit(this ref ulong bitboard, int index)
    {
        bitboard &= ~index.ToBitboard();
    }

    /// <summary>
    /// Switches (XORs) the given bit on the bitboard
    /// </summary>
    public static void SwitchBit(this ref ulong bitboard, int index)
    {
        bitboard ^= index.ToBitboard();
    }
}