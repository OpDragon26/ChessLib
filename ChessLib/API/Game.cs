using System.Collections;
using ChessLib.Base;

namespace ChessLib.API;

public class Game(Board starting) : IEnumerable<Node>
{
    private readonly List<Node> _moves = new();
    private readonly Board _current = starting;
    
    public Node this[int i] => _moves[i];
    public Node this[Index i] => _moves[i];

    public void MakeMove(Move move)
    {
        _moves.Add(new Node(_current.Clone(), move));
        _current.MakeMove(move);
    }
    
    public IEnumerator GetEnumerator()
    {
        return _moves.GetEnumerator();
    }

    IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
    {
        return _moves.GetEnumerator();
    }
}