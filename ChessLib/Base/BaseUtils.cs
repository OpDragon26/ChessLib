namespace ChessLib.Base;

public static class BaseUtils
{
    public static int GetOffset(this int color)
    {
        return color * 2 - 1;
    }

    public static int Switch(this int turn)
    {
        return 1 - turn;
    }
}