using ChessLib.API.Display.Formatting;
using ChessLib.Base;

namespace ChessLib.API.Display;

public static class Display
{
    public static string GetBoardString(Board board, PieceFormat format, int perspective = 0, bool debug = false)
    {
        string boardString = "";

        boardString += perspective == 0 ? "# A B C D E F G H" : "# H G F E D C B A";

        int rank = 0;
        for (int square = 0; square < 64; square++)
        {
            int s = perspective == 0 ? square : 63 - square;

            if (s % 8 == 0)
                boardString += $"";
        }

        return boardString;
    }
}