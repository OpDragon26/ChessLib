using ChessLib.API.Generic;
using ChessLib.Base.utils;
using ChessLib.Base.Utils;
using ChessLib.Bitboards;
using static ChessLib.Base.Pieces;

namespace ChessLib.Base;

public class Board
{
    public int Turn;
    public Bitboard Bitboards;
    public PiecewiseBoard PiecewiseBoard;
    public CastlingRights CastlingRights;
    
    public MutableValuePair<int> KingPositions;
    public int EnPassantSquare;
    
    public byte this[int index] => PiecewiseBoard[index];
    public byte this[Coordinate c] => this[c.AsIndex()];
    
    public Board(PiecewiseBoard board, int turn = 0, int enPassantSquare = 0, CastlingRights castlingRights = new())
    {
        PiecewiseBoard = board;
        Bitboards = new();
        Turn = turn;
        EnPassantSquare = enPassantSquare;
        CastlingRights = castlingRights;
        
        AutoInit();
    }

    /// <summary>
    /// Returns a board with the exact same position 
    /// </summary>
    public Board Clone()
    {
        return new Board(this);
    }
    
    private Board(Board board)
    {
        Turn = board.Turn;
        Bitboards = board.Bitboards;
        PiecewiseBoard = board.PiecewiseBoard;
        KingPositions = board.KingPositions;
        EnPassantSquare = board.EnPassantSquare;
    }
    
    /// <summary>
    /// Makes the given move on the board
    /// </summary>
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

        if (sourcePiece.IsType(King))
        {
            KingPositions[Turn] = move.Target;
            
        }
        
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
                EnPassantSquare = move.Target + 8 * Turn.GetOffset();
                break;
            
            case Flag.EnPassant:
                int capturedSquare = move.Target - 8 * Turn.GetOffset();
                byte pawn = PiecewiseBoard[capturedSquare];
                PiecewiseBoard[capturedSquare] = Empty; 
                Bitboards[pawn].DisableBit(capturedSquare);
                break;
            
            case Flag.ShortCastle:
                MovePiece(move.Target + 1, move.Target - 1, Rook.AsColor(Turn));
                CastlingRights.SetSide(Turn, false);
                break;
            
            case Flag.LongCastle:
                MovePiece(move.Target - 2, move.Target + 1, Rook.AsColor(Turn));
                CastlingRights.SetSide(Turn, false);
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

    /// <summary>
    /// Reverses the last made move based on an UnMove
    /// </summary>
    public void UnmakeMove(UnMove unMove)
    {
        Turn = Turn.Switch();
        
        byte targetPiece = PiecewiseBoard[unMove.Target]; // resulting piece
        byte sourcePiece = unMove.Promotion ? Pawn.AsColor(Turn) : PiecewiseBoard[unMove.Target]; // starting piece

        PiecewiseBoard[unMove.Target] = unMove.Capture;
        PiecewiseBoard[unMove.Source] = sourcePiece;
        
        Bitboards[targetPiece].DisableBit(unMove.Target);
        Bitboards[sourcePiece].EnableBit(unMove.Source);
        
        if (unMove.IsCapture)
            Bitboards[unMove.Capture].EnableBit(unMove.Target);

        if (sourcePiece.IsType(King))
            KingPositions[Turn] = unMove.Source;

        EnPassantSquare = unMove.EnPassantSquare;
        if (unMove.Flag != Flag.None)
            HandleSpecialUnMove(unMove);
    }

    private void HandleSpecialUnMove(UnMove unMove)
    {
        switch (unMove.Flag)
        {
            case Flag.EnPassant:
                int capturedSquare = unMove.Target - 8 * Turn.GetOffset();
                byte pawn = Pawn.AsColor(Turn.Switch());

                PiecewiseBoard[capturedSquare] = pawn;
                Bitboards[pawn].EnableBit(capturedSquare);
                break;
            
            case Flag.ShortCastle:
                MovePiece(unMove.Target - 1, unMove.Target + 1, Rook.AsColor(Turn));
                break;
            
            case Flag.LongCastle:
                MovePiece(unMove.Target + 1, unMove.Target - 2, Rook.AsColor(Turn));
                break;
        }
    }

    /// <summary>
    /// Generates an UnMove, used to reverse the last made move
    /// </summary>
    public UnMove GenerateUnMove(Move move)
    {
        byte capture = PiecewiseBoard[move.Target];
        return new UnMove(move.Source, move.Target, capture, EnPassantSquare, move.IsPromotion, move.Flag);
    }

    /// <summary>
    /// Automatically fills in bitboards and the king's position based on the given piecewise board
    /// </summary>
    private void AutoInit()
    {
        for (int square = 0; square < 64; square++)
        {
            byte piece = PiecewiseBoard[square];
            Bitboards[piece].EnableBit(square);

            if (piece == WKing)
                KingPositions.White = square;
            else if (piece == BKing)
                KingPositions.Black = square;
        }
    }
}