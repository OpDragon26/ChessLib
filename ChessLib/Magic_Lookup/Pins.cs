using ChessLib.Bitboards.Utils;
using ChessLib.Magic_Lookup.Utils;
using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

public static class Pins
{
    public static Dictionary<int, int>[][] Pin = new Dictionary<int, int>[64][];
    
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

    public static PinState GeneratePinState(int square, ulong combination)
    {
        return new(
            GeneratePinState(square, combination, MovePattern.Rook),
            GeneratePinState(square, combination, MovePattern.Bishop)
            );
    }
}