using ChessLib.Bitboards;
using static ChessLib.Base.Pieces;

namespace ChessLib.Base;

public class Board
{
    public int Turn;
    public Bitboard Bitboards;
    public PiecewiseBoard PiecewiseBoard;
    public int EnPassantSquare;

    public void MakeMove(Move move)
    {
        ulong enemyPieces = Turn == 0 ? Bitboards.AllBlack : Bitboards.AllWhite;
        bool capture = enemyPieces.Occupied(move.Target);

        byte selectedPiece = move.IsPromotion ? move.Promotion : PiecewiseBoard[move.Source];
        byte targetPiece = PiecewiseBoard[move.Target];
        
        MovePiece(move.Source, move.Target, selectedPiece);
        if (capture)
            Bitboards[targetPiece].DisableBit(move.Target);
        
        // handle castling and double moves
        EnPassantSquare = 0;
        if (move.Flag != Flag.None)
            HandleSpecialMove(move);
        
        Turn = 1 - Turn;
    }

    private void HandleSpecialMove(Move move)
    {
        switch (move.Flag)
        {
            case Flag.DoublePawn:
                EnPassantSquare = move.Target - 8 * Turn.GetOffset();
                break;
            
            case Flag.ShortCastle:
                MovePiece(move.Target + 1, move.Target - 1, Rook.AsColor(Turn));
                break;
            
            case Flag.LongCastle:
                MovePiece(move.Target - 2, move.Target + 1, Rook.AsColor(Turn));
                break;
        }
    }

    private void MovePiece(int source, int target, byte piece)
    {
        PiecewiseBoard[source] = Empty;
        PiecewiseBoard[target] = piece;
        
        Bitboards[piece].DisableBit(source);
        Bitboards[piece].EnableBit(target);
    }
}