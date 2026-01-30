using ChessLib.Bitboards;

namespace ChessLib.API.Display.Formatting;

public class BitFormat(char on, char off)
{
    public char FormatBit(bool bit)
    {
        return bit ? on : off;
    }

    public char FormatBit(ulong bit)
    {
        return FormatBit(bit != 0);
    }

    public char FormatBit(ulong bitboard, int index)
    {
        return FormatBit(bitboard.Occupied(index));
    }
}