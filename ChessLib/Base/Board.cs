using ChessLib.Bitboards;

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
        
        
    }
}