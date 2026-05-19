using ChessLib.API.Display;
using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Utils;
using static ChessLib.API.Parsing.ParsingUtils;

namespace ChessLib.API.Parsing;

public static class AlgebraicParsing
{
    /// <summary>
    /// Returns the Move object corresponding to the given move in Standard Algebraic Notation on the given board **Does not accurately check for legal moves
    /// </summary>
    public static Move ParseMove(this Board board, string move)
    {
        if (move[^1] is '#' or '+')
            return ParseMove(board, move[..^1]);

        switch (move.Length)
        {
            case 2:
                return ParseForwardPawn(board, move); // pawn move forward: e4
            case 3:
                if (move[1] == '-')
                    return board.IsWhiteTurn ? Move.WhiteShortCastle : Move.BlackShortCastle; // short castle: O-O
                return ParseRegularPieceMove(board, move); // undisambiguated piece move: Nc3
            case 4:
                if (move[1] == 'x')
                {
                    if (PieceParsing.ParsePiece(move[0]) == byte.MaxValue)
                        return ParsePawnCapture(board, move); // pawn capture: exd5
                    return ParsePieceCapture(board, move); // undisambiguated piece capture: Nxe5
                }
                if (move[2] == '=')
                    return ParseNonCapturePromotion(board, move); // non-capture promotion: e8=Q
                return ParseSingleDisambiguatedMove(board, move); // single-disambiguated piece move: Nbc3
            case 5:
                // double-disambiguated piece move: Ne3f5
                // single-disambiguated piece capture: Nexf5
                if (move[1] == '-')
                    return board.IsWhiteTurn ? Move.WhiteLongCastle : Move.BlackLongCastle; // long castle: O-O-O
                if (move[2] == 'x')
                break;
        }
        
        throw new ThrowHelper.NotationParsingException($"Incorrect move formatting: {move}");
    }

    private static Move ParseSingleDisambiguatedMove(Board board, string move)
    {
        byte type = move.ParsePieceType();
        int target = move[2..].ParseSquare().AsIndex();

        (Disambiguation disambiguation, int d) = ParseDisambiguation(move[1], move);
        
        FinderMask finder = GetFinderMask(board, type, target);
        int source = FindMovingPiece(board, finder, disambiguation, d);
        
        return new Move(source, target);
    }

    private static byte ParsePieceType(this string move, int index = 0)
    {
        byte type = PieceParsing.ParsePiece(move[index]).Type();
        if (type == byte.MaxValue)
            throw new ThrowHelper.NotationParsingException($"Unable to parse piece: {move}");
        return type;
    }

    private static (Disambiguation disambiguation, int d) ParseDisambiguation(char d, string? move = null)
    {
        if (d.IsFileChar())
            return (Disambiguation.File, d.GetFile());
        if (d.IsRankChar())
            return (Disambiguation.Rank, d.GetRank());
        throw new ThrowHelper.NotationParsingException($"Incorrect disambiguation: {move ?? d.ToString()}");
    }

    private static Move ParseNonCapturePromotion(Board board, string move)
    {
        (int file, int rank) target = move[..2].ParseSquare();
        (int file, int rank) source = target.OffsetRank(board.Turn.GetOffset());
        byte piece = ParsePieceType(move, 3);
        
        return new Move(source, target, piece);
    }

    private static Move ParsePieceCapture(Board board, string move)
    {
        move = move[0] + move[2..];
        return ParseRegularPieceMove(board, move);
    }

    private static Move ParsePawnCapture(Board board, string move)
    {
        (int file, int rank) target = move[2..4].ParseSquare();
        (int file, int rank) source = (move[0].GetFile(), target.rank + board.Turn.GetOffset());
        
        return new Move(source, target);
    }

    private static Move ParseForwardPawn(Board board, string move)
    {
        (int file, int rank) target = move.ParseSquare();
        int offset = board.Turn.GetOffset();
        (int file, int rank) source = target.OffsetRank(offset);
        
        if (board[source].IsType(Pieces.Pawn))
            return new Move(source, target);

        if (target.file == 3 + board.Turn)
        {
            source = target.OffsetRank(offset);
            return new Move(source, target, flag: Flag.DoublePawn);
        }

        throw new ThrowHelper.NotationParsingException($"Pawn not found: {move}");
    }

    private static Move ParseRegularPieceMove(Board board, string move)
    {
        byte type = move.ParsePieceType();
        int target = move[1..].ParseSquare().AsIndex();

        FinderMask finder = GetFinderMask(board, type, target);
        int source = FindMovingPiece(board, finder);
        
        return new Move(source, target);
    }
}