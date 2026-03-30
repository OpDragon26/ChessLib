using ChessLib.Bitboards;
using ChessLib.Bitboards.Utils;
using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

/// <summary>
/// Requires Combinations to be initialized first
/// </summary>
public static class Moves
{
    private static bool Initialized;
    
    public static readonly ulong[][] RookBitboard = new ulong[64][];
    public static readonly ulong[][] BishopBitboard = new ulong[64][];
    public static readonly ulong[][] KnightBitboard = new ulong[64][];
    public static readonly ulong[][] QueenBitboard = new ulong[64][];
    public static readonly ulong[][] KingBitboard = new ulong[64][];

    public static void Init()
    {
        if (Initialized)
            return;
        Initialized = true;
        
        for (int i = 0; i < 64; i++)
        {
            BishopBitboard[i] = new ulong[MagicNumbers.Bishop[i].Max];
            foreach (ulong combination in Combinations.Bishop[i])
            {
                ulong bitboard = GenBitboardMoves(i, combination, MovePattern.Bishop);
                ulong index = MagicNumbers.Bishop[i].Calculate(combination);
                BishopBitboard[i][index] = bitboard;
            }
            
            RookBitboard[i] = new ulong[MagicNumbers.Rook[i].Max];
            foreach (ulong combination in Combinations.Rook[i])
            {
                ulong bitboard = GenBitboardMoves(i, combination, MovePattern.Rook);
                ulong index = MagicNumbers.Rook[i].Calculate(combination);
                RookBitboard[i][index] = bitboard;
            }
        }
    }
    
    public static ulong GenBitboardMoves(int square, ulong blockers, MovePattern pattern)
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