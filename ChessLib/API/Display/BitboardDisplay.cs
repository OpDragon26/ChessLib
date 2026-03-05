using ChessLib.API.Display.Formatting;
using ChessLib.API.Generic;
using ChessLib.Bitboards;

namespace ChessLib.API.Display;

public static class BitboardDisplay
{
    public static string GetBitboardString(this ulong bitboard, BitFormat format, int perspective = 0)
    {
        Console.Write(perspective == 0 ? "# A B C D E F G H " : "# H G F E D C B A ");
        string bitboardString = "";
        
        for (int square = 0; square < 64; square++)
        {
            Perspective p = (Perspective)perspective;
            Coordinate subjective = new(p, square);
            Coordinate objective = subjective.ToObjective();
            
            if (subjective.File == 0)
            {
                bitboardString += $"\n{objective.Rank + 1} ";
            }

            int index = objective.AsIndex();
            bitboardString += format.FormatBit(bitboard.Occupied(index)) + " ";
        }
        
        return bitboardString;
    }

    public static string GetBitboardString(this ulong bitboard, int perspective = 0)
    {
        return GetBitboardString(bitboard, DefaultFormatting.Bitboard, perspective);
    }

    public static void PrintBitboard(this ulong bitboard, BitFormat format, int perspective = 0)
    {
        Console.WriteLine(GetBitboardString(bitboard, format, perspective));
    }

    public static void PrintBitboard(this ulong bitboard, int perspective = 0)
    {
        Console.WriteLine(GetBitboardString(bitboard, perspective));
    }
}