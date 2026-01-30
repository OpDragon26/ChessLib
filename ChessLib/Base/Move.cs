namespace ChessLib.Base;

public readonly struct Move(int source, int target, byte promotion = 0, Flag flag = Flag.None)
{
    public readonly int Source = source;
    public readonly int Target = target;
    public readonly byte Promotion = promotion;
    public readonly Flag Flag = flag;

    public bool IsPromotion => Promotion == 0;
}

public enum Flag : byte
{
    None,
    DoublePawn,
    EnPassant,
    ShortCastle,
    LongCastle,
}