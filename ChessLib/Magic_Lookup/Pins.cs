using ChessLib.Bitboards;
using ChessLib.Bitboards.Utils;
using ChessLib.Magic_Lookup.Utils;
using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

/// <summary>
/// Requires Combinations to be initialized first
/// </summary>
public static class Pins
{
    public static readonly Dictionary<int, int>[][] Rook = new Dictionary<int, int>[64][];
    public static readonly Dictionary<int, int>[][] Bishop = new Dictionary<int, int>[64][];
    private static bool Initialized = false;
    
    /// <summary>
    /// Initialize lookup tables. Requires combinations to be initialized
    /// </summary>
    public static void Init()
    {
        if (Initialized)
            return;
        Initialized = true;
        
        Rook.FillLookupTable(MagicNumbers.Rook, Combinations.Rook, (s, c) => GeneratePinState(s, c, MovePattern.Rook));
        Bishop.FillLookupTable(MagicNumbers.Bishop, Combinations.Bishop, (s, c) => GeneratePinState(s, c, MovePattern.Bishop));
    }
    
    public static Dictionary<int, int> GeneratePinState(int square, ulong combination, MovePattern pattern)
    {
        Dictionary<int, int> pinState = new();
        (int file, int rank) origin = square.AsSquare();
        
        foreach ((int file, int rank) offset in pattern.Offsets)
        {
            int previous = -1;
            
            for (int d = 1; d < 8; d++)
            {
                (int file, int rank) target = origin.OffsetBy(offset, d);
                if (target.OutOfBounds())
                    break;

                if (combination.Occupied(target))
                {
                    if (previous == -1)
                        previous = target.AsIndex();
                    else
                    {
                        pinState.Add(previous, target.AsIndex());
                        break;
                    }
                }
            }
        }

        return pinState;
    }
}