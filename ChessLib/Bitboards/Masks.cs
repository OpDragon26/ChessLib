using ChessLib.Bitboards.Utils;
using ChessLib.Utils;
using static ChessLib.Bitboards.Utils.MaskUtils;

namespace ChessLib.Bitboards;

/// <summary>
/// Contains all necessary masks as bitboards
/// </summary>
public static class Masks
{
    // A mask is a set of squares considered relevant for a given situation. By using an AND operation between a
    // bitboard and a mask, you get back the relevant squares of the bitboard
    // Move bitboards contain the squares a piece could move to from a given square (index) on an empty board
    // When calculating legal moves, blocking pieces not relevant to the movement of the given piece can be filtered
    // out using a mask.
    
    private static bool Initialized;

    public static readonly ulong[] Rook = new ulong[64];
    public static readonly ulong[] Bishop = new ulong[64];
    public static readonly ulong[] Knight = new ulong[64];
    public static readonly ulong[] Queen = new ulong[64];
    public static readonly ulong[] King = new ulong[64];
    
    public static void Init()
    {
        if (Initialized)
            return;
        Initialized = true;

        for (int square = 0; square < 64; square++)
        {
            Rook[square] = GenRookMask(square);
            Bishop[square] = GenBishopMask(square);
            Knight[square] = GenPieceMask(square, MovePattern.Knight);
            Queen[square] = Rook[square] | Bishop[square];
            King[square] = GenKingMask(square);
        }
    }
    
    private static ulong GenKingMask(int square)
    {
        ulong mask = 0;
        
        (int file, int rank) origin = square.AsSquare();
        for (int i = -1; i < 2; i++)
        for (int j = -1; j < 2; j++)
        {
            (int file, int rank) target = origin.OffsetBy((i, j));
            if (!target.OutOfBounds())
                mask |= target.ToBitboard();
        }
        mask ^= origin.ToBitboard();
        
        return mask;
    }

    private static ulong GenRookMask(int square)
    {
        (int file, int rank) origin = square.AsSquare();
        return GetFile(origin.file) ^ GetRank(origin.rank);
    }

    private static ulong GenBishopMask(int square)
    {
        (int file, int rank) origin = square.AsSquare();
        return GetUD(origin) ^ GetDD(origin);
    }
    
    private static ulong GenPieceMask(int square, MovePattern pattern)
    {
        (int file, int rank) origin = square.AsSquare();
        ulong mask = 0;
        
        int l = pattern.Sliding ? 8 : 2;
        
        foreach ((int file, int rank) offset in pattern.Offsets)
        {
            for (int d = 1; d < l; d++)
            {
                (int file, int rank) target = origin.OffsetBy(offset, d);
                if (target.OutOfBounds())
                    break;
                
                mask.EnableBit(target.AsIndex());
            }
        }

        return mask;
    }
}