using System.Numerics;
using ChessLib.Base;
using ChessLib.Bitboards;
using ChessLib.Bitboards.Utils;
using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

/// <summary>
/// Requires Combinations to be initialized first
/// </summary>
public static class Moves
{
    // Magic lookup tables for legal moves
    
    private static bool Initialized;
    
    public static readonly ulong[][] RookBitboard = new ulong[64][];
    public static readonly ulong[][] BishopBitboard = new ulong[64][];

    public static readonly Move[][][] Rook = new Move[64][][];
    public static readonly Move[][][] RookFree = new Move[64][][];
    public static readonly Move[][][] Bishop = new Move[64][][];
    public static readonly Move[][][] BishopFree = new Move[64][][];
    public static readonly Move[][][] Knight = new Move[64][][];
    public static readonly Move[][][] King = new Move[64][][];

    public static void Init()
    {
        if (Initialized)
            return;
        Initialized = true;
        
        for (int s = 0; s < 64; s++)
        {
            BishopBitboard[s] = new ulong[MagicNumbers.Bishop[s].Max];
            Bishop[s] = new Move[MagicNumbers.Bishop[s].Max][];
            BishopFree[s] = new Move[MagicNumbers.Bishop[s].Max][];
            foreach (ulong combination in Combinations.Bishop[s])
            {
                ulong bitboard = GenBitboardMoves(s, combination, MovePattern.Bishop, true);
                ulong index = MagicNumbers.Bishop[s].Calculate(combination);
                
                BishopBitboard[s][index] = bitboard;
                Bishop[s][index] = GenMoveSet(s, GenBitboardMoves(s, combination, MovePattern.Bishop, false));
                BishopFree[s][index] = GenMoveSet(s, combination);
            }
            
            RookBitboard[s] = new ulong[MagicNumbers.Rook[s].Max];
            Rook[s] = new Move[MagicNumbers.Rook[s].Max][];
            RookFree[s] = new Move[MagicNumbers.Rook[s].Max][];
            foreach (ulong combination in Combinations.Rook[s])
            {
                ulong bitboard = GenBitboardMoves(s, combination, MovePattern.Rook, true);
                ulong index = MagicNumbers.Rook[s].Calculate(combination);
                
                RookBitboard[s][index] = bitboard;
                Rook[s][index] = GenMoveSet(s, GenBitboardMoves(s, combination, MovePattern.Rook, false));
                RookFree[s][index] = GenMoveSet(s, combination);
            }

            Knight[s] = new Move[MagicNumbers.Knight[s].Max][];
            foreach (ulong combination in Combinations.Knight[s])
            {
                ulong bitboard = Masks.Knight[s] & ~combination;
                ulong index = MagicNumbers.Knight[s].Calculate(combination);

                Knight[s][index] = GenMoveSet(s, bitboard);
            }
            
            King[s] = new Move[MagicNumbers.King[s].Max][];
            foreach (ulong combination in Combinations.King[s])
            {
                ulong bitboard = Masks.King[s] & ~combination;
                ulong index = MagicNumbers.King[s].Calculate(combination);

                King[s][index] = GenMoveSet(s, bitboard);
            }
        }
    }
    
    /// <summary>
    /// Calculates the bitboard of legal moves from a square given a set of blockers and a piece movement pattern
    /// </summary>
    public static ulong GenBitboardMoves(int square, ulong blockers, MovePattern pattern, bool allowCapture)
    {
        (int File, int rank) origin = square.AsSquare();
        ulong moves = 0;
        int l = pattern.Sliding ? 8 : 2;
        
        
        foreach ((int file, int rank) offset in pattern.Offsets)
        {
            for (int d = 1; d < l; d++)
            {
                (int file, int rank) target = origin.OffsetBy(offset, d);
                if (target.OutOfBounds())
                    break;
                moves.EnableBit(target.AsIndex());
                if (blockers.Occupied(target))
                {
                    if (!allowCapture)
                        moves.DisableBit(target.AsIndex());
                    break;
                }
            }
        }

        return moves;
    }

    public static Move[] GenMoveSet(int square, ulong combination)
    {
        Move[] moves = new Move[combination.Count()];
        for (int i = 0; i < combination.Count(); i++)
        {
            int target = combination.LastBitSet().ToIndex();
            combination.DisableBit(target);

            moves[i] = new Move(square, target);
        }

        return moves;
    }
}