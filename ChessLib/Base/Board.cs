using ChessLib.API.Generic;
using ChessLib.Base.utils;
using ChessLib.Base.Utils;
using ChessLib.Bitboards;
using static ChessLib.Base.Pieces;

namespace ChessLib.Base;

public class Board
{
    private int _turn;
    private Bitboard _bitboards;
    private PiecewiseBoard _piecewiseBoard;

    private MutableValuePair<int> _kingPositions;
    private int _enPassantSquare;
    
    public byte this[int index] => _piecewiseBoard[index];
    public byte this[Coordinate c] => this[c.AsIndex()];

    public int Turn => _turn;
    public Bitboard Bitboards => _bitboards;
    public PiecewiseBoard PiecewiseBoard => _piecewiseBoard;
    public MutableValuePair<int> KingPositions => _kingPositions;
    public int EnPassantSquare => _enPassantSquare;
    
    public Board(PiecewiseBoard board, int turn = 0, int enPassantSquare = 0)
    {
        _piecewiseBoard = board;
        _bitboards = new();
        _turn = turn;
        _enPassantSquare = enPassantSquare;
        
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
        _turn = board.Turn;
        _bitboards = board.Bitboards;
        _piecewiseBoard = board.PiecewiseBoard;
        _kingPositions = board.KingPositions;
        _enPassantSquare = board.EnPassantSquare;
    }
    
    /// <summary>
    /// Makes the given move on the board
    /// </summary>
    public void MakeMove(Move move)
    {
        byte sourcePiece = _piecewiseBoard[move.Source];
        byte selectedPiece = move.IsPromotion ? move.Promotion : sourcePiece;
        byte targetPiece = _piecewiseBoard[move.Target];

        _piecewiseBoard[move.Source] = Empty;
        _piecewiseBoard[move.Target] = selectedPiece;
        
        _bitboards[sourcePiece].DisableBit(move.Source);
        _bitboards[selectedPiece].EnableBit(move.Target);
        
        if (targetPiece != Empty)
            _bitboards[targetPiece].DisableBit(move.Target);

        if (sourcePiece.IsType(King))
            _kingPositions[_turn] = move.Target;
        
        // handle castling and double moves
        _enPassantSquare = 0;
        if (move.Flag != Flag.None)
            HandleSpecialMove(move);
        
        _turn = _turn.Switch();
    }

    private void HandleSpecialMove(Move move)
    {
        switch (move.Flag)
        {
            case Flag.DoublePawn:
                _enPassantSquare = move.Target + 8 * _turn.GetOffset();
                break;
            
            case Flag.EnPassant:
                int capturedSquare = move.Target - 8 * _turn.GetOffset();
                byte pawn = _piecewiseBoard[capturedSquare];
                _piecewiseBoard[capturedSquare] = Empty;
                _bitboards[pawn].DisableBit(capturedSquare);
                break;
            
            case Flag.ShortCastle:
                MovePiece(move.Target + 1, move.Target - 1, Rook.AsColor(_turn));
                break;
            
            case Flag.LongCastle:
                MovePiece(move.Target - 2, move.Target + 1, Rook.AsColor(_turn));
                break;
        }
    }

    private void MovePiece(int source, int target, byte piece)
    {
        _piecewiseBoard[source] = Empty;
        _piecewiseBoard[target] = piece;
        
        _bitboards[piece].DisableBit(source);
        _bitboards[piece].EnableBit(target);
    }

    /// <summary>
    /// Reverses the last made move based on an UnMove
    /// </summary>
    public void UnmakeMove(UnMove unMove)
    {
        _turn = _turn.Switch();
        
        byte targetPiece = _piecewiseBoard[unMove.Target]; // resulting piece
        byte sourcePiece = unMove.Promotion ? Pawn.AsColor(_turn) : _piecewiseBoard[unMove.Target]; // starting piece

        _piecewiseBoard[unMove.Target] = unMove.Capture;
        _piecewiseBoard[unMove.Source] = sourcePiece;
        
        _bitboards[targetPiece].DisableBit(unMove.Target);
        _bitboards[sourcePiece].EnableBit(unMove.Source);
        
        if (unMove.IsCapture)
            _bitboards[unMove.Capture].EnableBit(unMove.Target);

        if (sourcePiece.IsType(King))
            _kingPositions[_turn] = unMove.Source;

        _enPassantSquare = unMove.EnPassantSquare;
        if (unMove.Flag != Flag.None)
            HandleSpecialUnMove(unMove);
    }

    private void HandleSpecialUnMove(UnMove unMove)
    {
        switch (unMove.Flag)
        {
            case Flag.EnPassant:
                int capturedSquare = unMove.Target - 8 * _turn.GetOffset();
                byte pawn = Pawn.AsColor(_turn.Switch());

                _piecewiseBoard[capturedSquare] = pawn;
                _bitboards[pawn].EnableBit(capturedSquare);
                break;
            
            case Flag.ShortCastle:
                MovePiece(unMove.Target - 1, unMove.Target + 1, Rook.AsColor(_turn));
                break;
            
            case Flag.LongCastle:
                MovePiece(unMove.Target + 1, unMove.Target - 2, Rook.AsColor(_turn));
                break;
        }
    }

    /// <summary>
    /// Generates an UnMove, used to reverse the last made move
    /// </summary>
    public UnMove GenerateUnMove(Move move)
    {
        byte capture = _piecewiseBoard[move.Target];
        return new UnMove(move.Source, move.Target, capture, _enPassantSquare, move.IsPromotion, move.Flag);
    }

    /// <summary>
    /// Automatically fills in bitboards and the king's position based on the given piecewise board
    /// </summary>
    private void AutoInit()
    {
        for (int square = 0; square < 64; square++)
        {
            byte piece = _piecewiseBoard[square];
            _bitboards[piece].EnableBit(square);

            if (piece == WKing)
                _kingPositions.White = square;
            else if (piece == BKing)
                _kingPositions.Black = square;
        }
    }
}