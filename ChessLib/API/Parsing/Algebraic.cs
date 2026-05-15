using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Utils;
using static ChessLib.API.Parsing.ParsingUtils;

namespace ChessLib.API.Parsing;

public static class Algebraic
{
    /// <summary>
    /// Returns the Move object corresponding to the given move in Standard Algebraic Notation on the given board !Does not accurately check for legal moves!
    /// </summary>
    public static Move ParseMove(this Board board, string move)
    {
        if (move[^1] is '#' or '+')
            return ParseMove(board, move[..^1]);

        return move.Length switch
        {
            2 => ParseForwardPawn(board, move), // pawn move forward: e4
            3 => ParseRegularPieceMove(board, move), // undisambiguated piece move: Nc3
            _ => throw new ThrowHelper.NotationParsingException($"Incorrect formatting: {move}")
        };
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
        byte type = Piece.ParsePiece(move[0]);
        
        int target = move[1..].ParseSquare().AsIndex();

        FinderMask finder = GetFinderMask(board, type, target);
        int source = FindMovingPiece(board, finder);
        
        return new Move(source, target);
    }
}