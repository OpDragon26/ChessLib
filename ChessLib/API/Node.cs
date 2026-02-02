using ChessLib.Base;

namespace ChessLib.API;

public struct Node(Board board, Move move)
{
    public Board Board = board;
    public Move Move = move;
}