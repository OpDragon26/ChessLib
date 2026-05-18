using ChessLib.API.Display;
using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Bitboards;
using ChessLib.Bitboards.Utils;
using ChessLib.Magic_Lookup;
using ChessLib.Magic_Lookup.Utils;
using ChessLib.Utils;

namespace ChessLib.API.Parsing;

public static class ParsingUtils
{
    /// <summary>
    /// Parse algebraic square notation to a file-rank tuple
    /// </summary>
    /// <example>
    /// "e4" -> (4, 3)
    /// </example>
    public static (int file, int rank) ParseSquare(this string square)
    {
        int file = square[0].GetFile();
        int rank = square[1].GetRank();

        return (file, rank);
    }

    /// <summary>
    /// Contains information necessary for finding a piece that could move to a given square
    /// </summary>
    public struct FinderMask(ulong mask, byte type, int target)
    {
        public readonly ulong Mask = mask;
        public readonly byte Type = type;
        public readonly int Target = target;
    }

    /// <summary>
    /// Type of disambiguation
    /// </summary>
    public enum Disambiguation : byte
    {
        None,
        File,
        Rank,
        Double,
    }

    /// <summary>
    /// Calculates information necessary for finding a piece that could move to a given square
    /// </summary>
    public static FinderMask GetFinderMask(Board board, byte type, int square)
    {
        ulong pieces = board.Bitboards.All;
        return type switch
        {
            Pieces.Knight => new(Masks.Knight[square], type, square),
            Pieces.Bishop => new(MagicLookup.Moves.BishopBitboard(square, pieces), type, square),
            Pieces.Rook => new(MagicLookup.Moves.RookBitboard(square, pieces), type, square),
            Pieces.Queen => new(MagicLookup.Moves.RookBitboard(square, pieces) | MagicLookup.Moves.BishopBitboard(square, pieces), type, square),
            Pieces.King => new(Masks.King[square], type, square),
            _ => throw new ThrowHelper.PieceTypeNotSupported($"Function does not accept type: {type}")
        };
    }

    /// <summary>
    /// Uses a finder mask to figure out which piece can move to the given location
    /// </summary>
    public static int FindMovingPiece(Board board, FinderMask finder, Disambiguation disambiguation = Disambiguation.None, int d = -1)
    {
        ulong potentialPieces = finder.Mask & board.Bitboards[finder.Type.AsColor(board.Turn)];
        if (disambiguation == Disambiguation.File)
            potentialPieces &= MaskUtils.GetFile(d);
        if (disambiguation == Disambiguation.Rank)
            potentialPieces &= MaskUtils.GetRank(d);

        if (ulong.PopCount(potentialPieces) == 1)
            return potentialPieces.ToIndex();

        potentialPieces.FilterPins(board, finder);
        
        if (ulong.PopCount(potentialPieces) == 1)
            return potentialPieces.ToIndex();

        throw new ThrowHelper.PieceAmbiguityException($"Unable to determine moving piece - expected: 1, found instead: {ulong.PopCount(potentialPieces)}");
    }

    private static void FilterPins(this ref ulong potentialPieces, Board board, FinderMask finder)
    {
        for (int s = 0; s < 64; s++)
        {
            PinState pins = board.FindPins();

            if (potentialPieces.Occupied(s))
            {
                ulong moves = MagicLookup.Moves.SwitchBitboard(finder.Type, s, board.Bitboards.All);
                if (pins.Bishop.TryGetValue(s, out int bishop))
                {
                    ulong pinLine = PinHelper.GetPinLine(board, s, bishop);
                    if (!(pinLine & moves).Occupied(finder.Target))
                        potentialPieces.DisableBit(s);
                        
                }
                else if (pins.Rook.TryGetValue(s, out int rook))
                {
                    ulong pinLine = PinHelper.GetPinLine(board, s, rook);
                    if (!(pinLine & moves).Occupied(finder.Target))
                        potentialPieces.DisableBit(s);
                }
            }
        }
    }
}