using ChessLib.API.Display.Formatting;
using ChessLib.Base;

namespace ChessLib.API.Display;

public static class Display
{
    public static string GetBoardString(Board board, PieceFormat format, int perspective = 0, bool debug = false)
    {
        string boardString = perspective == 0 ? "# A B C D E F G H" : "# H G F E D C B A";
        int rank = 0;
        
        for (int square = 0; square < 64; square++)
        {
            int s = perspective == 0 ? square.White() : square.Black();
            if (s % 8 == 0)
            {
                int r = perspective == 0 ? 8 - rank : rank + 1;
                boardString += $"\n{r} ";
            }
            boardString += " " + format.FormatPiece(board[s]);
        }

        if (debug)
            boardString += GetBoardDebugString(board);
                
        return boardString;
    }

    public static string GetBoardString(Board board, int perspective = 0, bool debug = false)
    {
        return GetBoardString(board, DefaultFormatting.GetOSDefault(), perspective, debug);
    }

    public static void PrintBoard(this Board board, PieceFormat format, int perspective = 0, bool debug = false)
    {
        Console.BackgroundColor = format.Light;
        Console.ForegroundColor = format.Dark;
        
        Console.Write(perspective == 0 ? "# A B C D E F G H" : "# H G F E D C B A");
        int rank = 0;
        
        for (int square = 0; square < 64; square++)
        {
            int s = perspective == 0 ? square.White() : square.Black();
            if (s % 8 == 0)
            {
                Console.BackgroundColor = format.Light;
                int r = perspective == 0 ? 8 - rank : rank + 1;
                Console.Write($"\n{r} ");
            }

            Console.BackgroundColor = format.GetColorAt(s);
            Console.Write($" {format.FormatPiece(board[s])}");
        }

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        if (debug)
            Console.WriteLine(GetBoardDebugString(board));
    }

    public static void PrintBoard(this Board board, int perspective = 0, bool debug = false)
    {
        PrintBoard(board, DefaultFormatting.GetOSDefault(), perspective, debug);
    }

    private static string GetBoardDebugString(Board board)
    {
        return $"\n| Turn: {(board.Turn == 0 ? "white" : "black")}" +
               "\n| King positions:" +
               $"\n|\tWhite: {board.KingPositions.White}" +
               $"\n|\tBlack: {board.KingPositions.Black}" +
               $"\n| En passant square: {board.EnPassantSquare.ToAlgebraic()}";
    }
}