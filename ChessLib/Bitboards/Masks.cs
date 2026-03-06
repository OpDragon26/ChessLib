using ChessLib.Bitboards.Utils;
using ChessLib.Utils;
using static ChessLib.Bitboards.Utils.MaskUtils;

namespace ChessLib.Bitboards;

public static class Masks
{
    private static bool Initialized;

    public static readonly ulong[] Rook = new ulong[64];
    public static readonly ulong[] Bishop = new ulong[64];
    public static readonly ulong[] Knight = new ulong[64];
    public static readonly ulong[] Queen = new ulong[64];
    
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
        }
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
        
        foreach ((int file, int rank) offset in pattern.Offsets)
        {
            int l = pattern.Repeat ? 8 : 2;
            
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