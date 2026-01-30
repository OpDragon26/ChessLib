namespace ChessLib.Base;

public readonly struct UnMove(int source, int target, byte capture = 0, int enPassantSquare = 0, bool promotion = false, Flag flag = Flag.None)
{
    public readonly int Source = source;
    public readonly int Target = target;
    public readonly byte Capture = capture;
    public readonly int EnPassantSquare = enPassantSquare;
    public readonly bool Promotion = promotion;
    public readonly Flag Flag = flag;

    public bool IsCapture => Capture == 0;
}