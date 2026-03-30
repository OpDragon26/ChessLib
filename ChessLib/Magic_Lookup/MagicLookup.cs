using ChessLib.Bitboards;

namespace ChessLib.Magic_Lookup;

public static class MagicLookup
{
    public static class Moves
    {
        public static ulong RookBitboard(int square, ulong blockers)
        {
            MagicNumber number = MagicNumbers.Rook[square];
            ulong index = number.Calculate(blockers & Masks.Rook[square]);
            return Magic_Lookup.Moves.RookBitboard[square][index];
        }
        
        public static ulong BishopBitboard(int square, ulong blockers)
        {
            MagicNumber number = MagicNumbers.Bishop[square];
            ulong index = number.Calculate(blockers & Masks.Rook[square]);
            return Magic_Lookup.Moves.BishopBitboard[square][index];
        }
    }
}