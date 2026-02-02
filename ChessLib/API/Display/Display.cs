using ChessLib.API.Display.Formatting;
using ChessLib.API.Generic;
using ChessLib.Base;

namespace ChessLib.API.Display;

public static class Display
{
    /// <summary>
    /// Returns a string with the given formatting representing the board
    /// </summary>
    public static string GetBoardString(Board board, PieceFormat format, int perspective = 0, bool debug = false)
    {
        string boardString = perspective == 0 ? "# A B C D E F G H" : "# H G F E D C B A";
        int rank = 0;
        
        for (int square = 0; square < 64; square++)
        {
            Perspective p = (Perspective)perspective;
            Coordinate subjective = new(p, square);
            Coordinate objective = subjective.ToObjective();
            if (subjective.File == 0)
            {
                boardString += $"\n{objective.Rank} ";
            }
            boardString += " " + format.FormatPiece(board[objective]);
        }

        if (debug)
            boardString += GetBoardDebugString(board);
                
        return boardString;
    }

    /// <summary>
    /// Returns a string with the default formatting representing the board
    /// </summary>
    public static string GetBoardString(Board board, int perspective = 0, bool debug = false)
    {
        return GetBoardString(board, DefaultFormatting.GetOSDefault(), perspective, debug);
    }

    /// <summary>
    /// Prints the board to the console with the given formatting
    /// </summary>
    public static void PrintBoard(this Board board, PieceFormat format, int perspective = 0, bool debug = false)
    {
        Console.BackgroundColor = format.Light;
        Console.ForegroundColor = format.Dark;
        
        Console.Write(perspective == 0 ? "# A B C D E F G H" : "# H G F E D C B A");
        
        for (int square = 0; square < 64; square++)
        {
            Perspective p = (Perspective)perspective;
            Coordinate subjective = new(p, square);
            Coordinate objective = subjective.ToObjective();
            if (subjective.File == 0)
            {
                Console.BackgroundColor = format.Light;
                Console.Write($"\n{objective.Rank} ");
            }

            Console.BackgroundColor = format.GetColorAt(subjective);
            Console.Write($" {format.FormatPiece(board[objective])}");
        }

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        if (debug)
            Console.WriteLine(GetBoardDebugString(board));
    }

    /// <summary>
    /// Returns a string with the default formatting representing the board
    /// </summary>
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