namespace ChessLib.Base;

public struct CastlingRights()
{
    private byte Castling = 0b1111;

    public bool WhiteShort
    {
        get => (Castling & WhiteShortCode) != 0;
        set
        {
            if (value)
                Castling |= WhiteShortCode;
            else
                Castling &= (~WhiteShortCode & 255);
        }
    }
    
    public bool WhiteLong
    {
        get => (Castling & WhiteLongCode) != 0;
        set
        {
            if (value)
                Castling |= WhiteLongCode;
            else
                Castling &= (~WhiteLongCode & 255);
        }
    }
    
    public bool BlackShort
    {
        get => (Castling & BlackShortCode) != 0;
        set
        {
            if (value)
                Castling |= BlackShortCode;
            else
                Castling &= (~BlackShortCode & 255);
        }
    }
    
    public bool BlackLong
    {
        get => (Castling & BlackLongCode) != 0;
        set
        {
            if (value)
                Castling |= BlackLongCode;
            else
                Castling &= (~BlackLongCode & 255);
        }
    }

    public bool White
    {
        get => (Castling & WhiteCode) != 0;
        set
        {
            if (value)
                Castling |= WhiteCode;
            else
                Castling &= BlackCode;
        }
    }

    public bool Black
    {
        get => (Castling & BlackCode) != 0;
        set
        {
            if (value)
                Castling |= BlackCode;
            else
                Castling &= WhiteCode;
        }
    }

    public void SetSide(int side, bool value)
    {
        if (side == 0)
            White = value;
        else
            Black = value;
    }
    
    private const int WhiteShortCode = 0b0001;
    private const int WhiteLongCode =  0b0010;
    private const int BlackShortCode = 0b0100;
    private const int BlackLongCode =  0b1000;
    private const int WhiteCode = 0b0011;
    private const int BlackCode = 0b1100;
}