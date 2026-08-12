using ChessLib.Base;

namespace ChessLib.API.Parsing;

public static class GameParsing
{
    /// <summary>
    /// Removes the move indicator numbers from a game string and returns the moves as a list
    /// </summary>
    public static string[] StripMoves(this string game)
    {
        string[] items = game.Split(' ');
        List<string> moves = new();
        foreach (string item in items)
            if (!item.Contains('.'))
                moves.Add(item);
        return moves.ToArray();
    }
}