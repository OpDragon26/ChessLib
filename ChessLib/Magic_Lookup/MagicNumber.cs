using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

/// <summary>
/// A magic number used to perfectly hash a set of values which are known ahead of time
/// </summary>
/// <example>
/// (v * Number) >> Shift returns an index for all values of v that were taken into account. Each index is equal to or lower than Max
/// </example>
public readonly struct MagicNumber(ulong number, int shift, int max)
{
    public readonly ulong Number = number;
    public readonly int Shift = shift;
    public readonly int Max = max;

    /// <summary>
    /// Calculates the index for the given value
    /// </summary>
    public ulong Calculate(ulong combination)
    {
        return (combination * Number) >> Shift;
    }
    
    public override string ToString()
    {
        return $"({Number.ToHex()} >> {Shift} | {Max})";
    }
    
    /// <summary>
    /// String for creating a magic number object with matching parameters
    /// </summary>
    public string ObjectString()
    {
        return $"new({Number.ToHex()}, {Shift}, {Max})";
    }

    /// <summary>
    /// Compares the magic number to another one and returns whether it's better or not
    /// </summary>
    public bool BetterThan(MagicNumber other)
    {
        return Shift > other.Shift || (Shift == other.Shift && Max < other.Max);
    }

    public static implicit operator MagicNumber((ulong number, int shift, int max) tuple) =>
        new(tuple.number, tuple.shift, tuple.max);
}