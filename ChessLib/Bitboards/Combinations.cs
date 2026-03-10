using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace ChessLib.Bitboards;

public static class Combinations
{
    private static bool Initialized;
    
    public static readonly ulong[][] Rook = new ulong[64][];
    public static readonly ulong[][] Bishop = new ulong[64][];
    public static readonly ulong[][] Knight = new ulong[64][];
    public static readonly ulong[][] Queen = new ulong[64][];
    public static readonly ulong[][] King = new ulong[64][];

    public static void Init()
    {
        if (Initialized) 
            return;
        Initialized = true;
    }

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