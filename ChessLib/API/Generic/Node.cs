using ChessLib.Base;

namespace ChessLib.API.Generic;

/// <summary>
/// Contains a board and the move made on it during a game
/// </summary>
public struct Node(Board board, Move move)
{
    public Board Board = board;
    public Move Move = move;
}