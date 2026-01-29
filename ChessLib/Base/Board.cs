using ChessLib.Bitboards;
using static ChessLib.Base.Pieces;

namespace ChessLib.Base;

public class Board
{
    public int Turn;
    public Bitboard Bitboards;
    public PiecewiseBoard PiecewiseBoard;

    public void MakeMove(Move move)
    {
        ulong enemyPieces = Turn == 0 ? Bitboards.AllBlack : Bitboards.AllWhite;
        bool capture = enemyPieces.Occupied(move.Target);

        byte selectedPiece = move.IsPromotion ? move.Promotion : PiecewiseBoard[move.Source];
        byte targetPiece = PiecewiseBoard[move.Target];
        
        // update the piecewise board
        PiecewiseBoard[move.Target] = selectedPiece;
        PiecewiseBoard[move.Source] = Empty;
        
        // update bitboards
        Bitboards[selectedPiece].DisableBit(move.Source);
        Bitboards[selectedPiece].EnableBit(move.Target);
        if (capture)
            Bitboards[targetPiece].DisableBit(move.Target);
        
        if (move.Flag != Flag.None)
            HandleSpecialMove(move);
        
        Turn = 1 - Turn;
    }

    private void HandleSpecialMove(Move move)
    {
        switch (move.Flag)
        {
            case Flag.DoublePawn:
                
                
                break;
        }
    }
}