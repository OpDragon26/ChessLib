using ChessLib.Bitboards;

namespace ChessLib.Magic_Lookup;

public static class MagicLookup
{
    public static class Moves
    {
        /// <summary>
        /// Returns a bitboard of all possible rook moves (captures included) on a bitboard given a set of blockers
        /// </summary>
        public static ulong RookBitboard(int square, ulong blockers)
        {
            MagicNumber number = MagicNumbers.Rook[square];
            ulong index = number.Calculate(blockers & Masks.Rook[square]);
            return Magic_Lookup.Moves.RookBitboard[square][index];
        }
        
        /// <summary>
        /// Returns a bitboard of all possible bishop moves (captures included) on a bitboard given a set of blockers
        /// </summary>
        public static ulong BishopBitboard(int square, ulong blockers)
        {
            MagicNumber number = MagicNumbers.Bishop[square];
            ulong index = number.Calculate(blockers & Masks.Bishop[square]);
            return Magic_Lookup.Moves.BishopBitboard[square][index];
        }

        /// <summary>
        /// Returns a bitboard of all possible queen moves (captures included) on a bitboard given a set of blockers
        /// </summary>
        public static ulong QueenBitboard(int square, ulong blockers)
        {
            return RookBitboard(square, blockers) | BishopBitboard(square, blockers);
        }
    }
}