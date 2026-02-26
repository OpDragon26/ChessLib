namespace ChessLib.Base;

public struct CastlingRights()
{
    private byte Castling = 0b1111;

    private bool WhiteShort
    {
        get => (Castling & 0b0001) != 0;
        set
        {
            if (value)
                Castling |= 0b0001;
            else
                Castling &= (~0b0001 & 255);
        }
    }
}