namespace ChessLib.Base.Utils;

public static class BaseUtils
{
    /// <summary>
    /// Returns the y offset for motion towards the back rank of each side (-1 for white, 1 for black)
    /// </summary>
    public static int GetOffset(this int color)
    {
        return color * 2 - 1;
    }

    /// <summary>
    /// Switches between 1 and 0
    /// </summary>
    public static int Switch(this int turn)
    {
        return 1 - turn;
    }
}