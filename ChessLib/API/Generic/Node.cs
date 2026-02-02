using ChessLib.Base;

namespace ChessLib.API.Generic;

public struct Node(Board board, Move move)
{
    public Board Board = board;
    public Move Move = move;
}