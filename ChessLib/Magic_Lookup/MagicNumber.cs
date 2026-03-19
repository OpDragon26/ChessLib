using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

public readonly struct MagicNumber(ulong number, int shift, int max)
{
    public readonly ulong Number = number;
    public readonly int Shift = shift;
    public readonly int Max = max;

    public ulong Calculate(ulong combination)
    {
        return (combination * Number) >> Shift;
    }

    public override string ToString()
    {
        return $"new({Number.ToHex()}, {Shift}, {Max})";
    }

    public bool BetterThan(MagicNumber other)
    {
        return Shift > other.Shift || (Shift == other.Shift && Max < other.Max);
    }

    public static implicit operator MagicNumber((ulong number, int shift, int max) tuple) =>
        new(tuple.number, tuple.shift, tuple.max);
}