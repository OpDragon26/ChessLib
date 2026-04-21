using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace ChessLib.Bitboards;

/// <summary>
/// Requires Masks to be initialized first
/// </summary>
public static class Combinations
{
    private static bool Initialized;
    
    public static readonly ulong[][] Rook = new ulong[64][];
    public static readonly ulong[][] Bishop = new ulong[64][];
    public static readonly ulong[][] Knight = new ulong[64][];
    public static readonly ulong[][] Queen = new ulong[64][];
    public static readonly ulong[][] King = new ulong[64][];
    public static readonly ulong[][] Pawn = new ulong[64][];
    
    
    public static void Init()
    {
        if (Initialized) 
            return;
        Initialized = true;
        
        for (int square = 0; square < 64; square++)
        {
            Rook[square] = GetCombinations(Masks.Rook[square]);
            Bishop[square] = GetCombinations(Masks.Bishop[square]);
            Knight[square] = GetCombinations(Masks.Knight[square]);
            Queen[square] = GetCombinations(Masks.Queen[square]);
            King[square] = GetCombinations(Masks.King[square]);
            Pawn[square] = GetCombinations(Masks.GetPawnAll(square));
        }
    }

    /// <summary>
    /// Returns an array of all possible combination of bits in places where the bit of the mask is 1 using PDEP
    /// </summary>
    /// <example>
    /// 0b0110 -> [0b0000, 0b0010, 0b0100, 0b0110]
    /// </example>
    public static ulong[] GetCombinations(ulong mask)
    {
        int k = BitOperations.PopCount(mask);
        ulong count = 1UL << k;
        ulong[] result = new ulong[count];
        
        for (ulong i = 0; i < count; i++)
            result[i] = Bmi2.X64.ParallelBitDeposit(i, mask);
        return result;
    }
}