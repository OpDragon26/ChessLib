using ChessLib.API.Display;
using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Utils;
using static ChessLib.API.Parsing.ParsingUtils;

namespace ChessLib.API.Parsing;

public static class Algebraic
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
                
                // single-disambiguated piece move: Nbc3
                break;
        }
        
        throw new ThrowHelper.NotationParsingException($"Incorrect move formatting: {move}");
    }

    private static Move ParseNonCapturePromotion(Board board, string move)
    {
        (int file, int rank) target = move[..2].ParseSquare();
        (int file, int rank) source = target.OffsetRank(board.Turn.GetOffset());
        byte piece = PieceParsing.ParsePiece(move[3]).Type();
        
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
        byte type = PieceParsing.ParsePiece(move[0]).Type();
        
        int target = move[1..].ParseSquare().AsIndex();

        FinderMask finder = GetFinderMask(board, type, target);
        int source = FindMovingPiece(board, finder);
        
        return new Move(source, target);
    }
}