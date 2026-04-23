namespace ChessLib.Magic_Lookup.Utils;

public struct PinState(Dictionary<int, int> rook, Dictionary<int, int> bishop)
{
    public Dictionary<int, int> Rook = rook;
    public Dictionary<int, int> Bishop = bishop;

    public PinState() : this(new(), new()) {}
}