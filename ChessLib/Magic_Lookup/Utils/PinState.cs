namespace ChessLib.Magic_Lookup.Utils;

public struct PinState(Dictionary<int, int> rook, Dictionary<int, int> bishop)
{
    public readonly Dictionary<int, int> Rook = rook;
    public readonly Dictionary<int, int> Bishop = bishop;

    public PinState() : this(new(), new()) {}
}