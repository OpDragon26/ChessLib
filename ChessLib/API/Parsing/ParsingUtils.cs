using ChessLib.API.Display;
using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Bitboards;
using ChessLib.Bitboards.Utils;
using ChessLib.Magic_Lookup;
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
    public struct FinderMask(ulong mask, byte type)
    {
        public ulong Mask = mask;
        public byte Type = type;
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
    public static FinderMask GetFinderMask(Board board, byte piece, int square)
    {
        return piece switch
        {
            Pieces.Knight => new(Masks.Knight[square], piece),
            Pieces.Bishop => new(MagicLookup.Moves.BishopBitboard(square, board.Bitboards.All), piece),
            Pieces.Rook => new(MagicLookup.Moves.RookBitboard(square, board.Bitboards.All), piece),
            Pieces.Queen => new(MagicLookup.Moves.RookBitboard(square, board.Bitboards.All) | MagicLookup.Moves.BishopBitboard(square, board.Bitboards.All), piece),
            Pieces.King => new(Masks.King[square], piece),
            _ => throw new ThrowHelper.NotationParsingException($"Unknown piece code: {piece}")
        };
    }

    /// <summary>
    /// Uses a finder mask to figure out which piece moved to the given location
    /// </summary>
    public static int FindMovingPiece(Board board, FinderMask finder, Disambiguation disambiguation, int d = -1)
    {
        ulong potentialPieces = finder.Mask & board.Bitboards[finder.Type.AsColor(board.Turn)];
        if (disambiguation == Disambiguation.File)
    }
}