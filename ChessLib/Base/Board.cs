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
        byte sourcePiece = PiecewiseBoard[move.Source];
        byte selectedPiece = move.IsPromotion ? move.Promotion : sourcePiece;
        byte targetPiece = PiecewiseBoard[move.Target];

        PiecewiseBoard[move.Source] = Empty;
        PiecewiseBoard[move.Target] = selectedPiece;
        
        Bitboards[sourcePiece].DisableBit(move.Source);
        Bitboards[selectedPiece].EnableBit(move.Target);
        
        if (targetPiece != Empty)
            Bitboards[targetPiece].DisableBit(move.Target);
        
        // handle castling and double moves
        EnPassantSquare = 0;
        if (move.Flag != Flag.None)
            HandleSpecialMove(move);
        
        Turn = Turn.Switch();
    }

    private void HandleSpecialMove(Move move)
    {
        switch (move.Flag)
        {
            case Flag.DoublePawn:
                EnPassantSquare = move.Target - 8 * Turn.GetOffset();
                break;
            
            case Flag.EnPassant:
                byte pawn = PiecewiseBoard[EnPassantSquare];
                PiecewiseBoard[EnPassantSquare] = Empty;
                Bitboards[pawn].DisableBit(EnPassantSquare);
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