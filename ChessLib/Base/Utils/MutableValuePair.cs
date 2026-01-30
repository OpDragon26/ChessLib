namespace ChessLib.Base.Utils;

public struct MutableValuePair<T>(T white, T black)
{
    public T White = white;
    public T Black = black;

    public T this[int index]
    {
        get => index == 0 ? White : Black;
        set
        {
            if (index == 0)
                White = value;
            else
                Black = value;
        }
    }
}