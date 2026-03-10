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
}