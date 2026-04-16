using System.Numerics;
using ChessLib.Utils;

namespace ChessLib.Bitboards.Utils;

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
    /// Returns the index represented by the single-square bitboard
    /// </summary>
    public static int ToIndex(this ulong bitboard)
    {
        return BitOperations.TrailingZeroCount(bitboard);
    }
    
    /// <summary>
    /// Returns the given file-rank tuple represented as a bitboard
    /// </summary>
    public static ulong ToBitboard(this (int file, int rank) square)
    {
        return square.AsIndex().ToBitboard();
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
    /// Returns whether the given index is turned to 1 on the bitboard
    /// </summary>
    public static bool Occupied(this ulong bitboard, (int file, int rank) square)
    {
        return bitboard.SharesBits(square.ToBitboard());
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

    /// <summary>
    /// Returns a bitboard with only the least significant bit of the original bitboard set to 1;
    /// </summary>
    public static ulong LastBitSet(this ulong bitboard)
    {
        return bitboard & (1UL << BitOperations.TrailingZeroCount(bitboard));
    }

    /// <summary>
    /// PopCount
    /// </summary>
    public static int Count(this ulong bitboard)
    {
        return BitOperations.PopCount(bitboard);
    }
}