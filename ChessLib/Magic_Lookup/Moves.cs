using System.Numerics;
using ChessLib.Base;
using ChessLib.Bitboards;
using ChessLib.Bitboards.Utils;
using ChessLib.Magic_Lookup.Utils;
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
    public static readonly Move[][][] Bishop = new Move[64][][];
    public static readonly Move[][][] Knight = new Move[64][][];
    public static readonly Move[][][] King = new Move[64][][];
    public static readonly Move[][][] Pawn = new Move[64][][];

    public static class Lookup
    {
        public static ulong RookBitboardLookup(int square, ulong friendly, ulong enemy)
        {
            ulong blockers = (friendly | enemy) & Masks.Rook[square];
            return RookBitboard.Lookup(MagicNumbers.Rook, square, blockers) & ~friendly;
        }
        
        public static ulong BishopBitboardLookup(int square, ulong friendly, ulong enemy)
        {
            ulong blockers = (friendly | enemy) & Masks.Bishop[square];
            return BishopBitboard.Lookup(MagicNumbers.Bishop, square, blockers) & ~friendly;
        }

        public static Move[] RookLookup(int square, ulong friendly, ulong enemy)
        {
            return Rook.Lookup(MagicNumbers.Rook, square, RookBitboardLookup(square, friendly, enemy));
        }
        
        public static Move[] BishopLookup(int square, ulong friendly, ulong enemy)
        {
            return Bishop.Lookup(MagicNumbers.Bishop, square, BishopBitboardLookup(square, friendly, enemy));
        }
        
        public static Move[] KnightLookup(int square, ulong friendly)
        {
            return Knight.Lookup(MagicNumbers.Knight, square, Masks.Knight[square] & ~friendly);
        }
        
        public static Move[] KingLookup(int square, ulong friendly)
        {
            return King.Lookup(MagicNumbers.King, square, Masks.King[square] & ~friendly);
        }

        public static ulong PawnBitboardLookup(int square, int color, ulong friendly, ulong enemy)
        {
            ulong all = friendly | enemy;
            ulong allDouble = all | (color == 0 ? all << 8 : all >> 8);
            return (~allDouble & Masks.GetPawnMove(square, color))
                   | (enemy & Masks.GetPawnCapture(square, color));
        }
        
        public static Move[] PawnLookup(int square, int color, ulong friendly, ulong enemy)
        {
            ulong bitboard = PawnBitboardLookup(square, color, friendly, enemy);
            return Pawn.Lookup(MagicNumbers.Pawn, square, bitboard);
        }
    }
    
    /// <summary>
    /// Initialize lookup tables
    /// </summary>
    public static void Init()
    {
        if (Initialized)
            return;
        Initialized = true;
        
        BishopBitboard.FillLookupTable(MagicNumbers.Bishop, Combinations.Bishop, 
            (s, c) => GenBitboardMoves(s, c, MovePattern.Bishop, true));
        RookBitboard.FillLookupTable(MagicNumbers.Rook, Combinations.Rook, 
            (s, c) => GenBitboardMoves(s, c, MovePattern.Rook, true));
        
        Bishop.FillLookupTable(MagicNumbers.Bishop, Combinations.Bishop, GenMoveSet);
        Rook.FillLookupTable(MagicNumbers.Rook, Combinations.Rook, GenMoveSet);
        Knight.FillLookupTable(MagicNumbers.Knight, Combinations.Knight, GenMoveSet);
        King.FillLookupTable(MagicNumbers.King, Combinations.King, GenMoveSet);

        MagicNumber[] magics = new MagicNumber[64];
        for (int s = 0; s < 64; s++)
        {
            magics[s] = MagicNumberGenerator.Generate()
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

    /// <summary>
    /// Generates a set of moves based on a bitboard
    /// </summary>
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
    
    public static Move[] GenPawnMoveSet(int square, ulong combination)
    {
        List<Move> moves = new List<Move>();
        for (int i = 0; i < combination.Count(); i++)
        {
            int target = combination.LastBitSet().ToIndex();
            combination.DisableBit(target);

            if (target < 8) // white promotion
            {
                moves.Add(new Move(square, target, promotion: Pieces.WQueen));
                moves.Add(new Move(square, target, promotion: Pieces.WKnight));
                moves.Add(new Move(square, target, promotion: Pieces.WBishop));
                moves.Add(new Move(square, target, promotion: Pieces.WRook));
            }
            else if (target > 55) // black promotion
            {
                moves.Add(new Move(square, target, promotion: Pieces.BQueen));
                moves.Add(new Move(square, target, promotion: Pieces.BKnight));
                moves.Add(new Move(square, target, promotion: Pieces.BBishop));
                moves.Add(new Move(square, target, promotion: Pieces.BRook));
            }
            else
                moves.Add(new Move(square, target));
        }

        return moves.ToArray();
    }
}