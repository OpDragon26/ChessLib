using ChessLib.Bitboards.Utils;
using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

/// <summary>
/// Requires Combinations to be initialized first
/// </summary>
public static class Moves
{
    public static readonly ulong[][] RookBitboard = new ulong[64][];
    public static readonly ulong[][] BishopBitboard = new ulong[64][];
    public static readonly ulong[][] KnightBitboard = new ulong[64][];
    public static readonly ulong[][] QueenBitboard = new ulong[64][];
    public static readonly ulong[][] KingBitboard = new ulong[64][];

    private static ulong GenBitboardMoves(int square, ulong blockers, MovePattern pattern)
    {
        (int File, int rank) origin = square.AsSquare();
        ulong moves = 0;
        int l = pattern.Repeat ? 8 : 2;
        
        
        foreach ((int file, int rank) offset in pattern.Offsets)
        {
            for (int d = 1; d < l; d++)
            {
                (int file, int rank) target = origin.OffsetBy(offset, d);
                if (target.OutOfBounds())
                    break;
                moves.EnableBit(target.AsIndex());
                if (blockers.Occupied(target))
                    break;
            }
        }

        return moves;
    }
}