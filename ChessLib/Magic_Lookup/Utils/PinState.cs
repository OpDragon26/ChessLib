namespace ChessLib.Magic_Lookup.Utils;

public struct PinState(Dictionary<int, int> rook, Dictionary<int, int> bishop)
{
    public Dictionary<int, int> Rook;
    public Dictionary<int, int> Bishop;
}