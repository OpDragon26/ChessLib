using System.Collections;
using ChessLib.API.Parsing;
using ChessLib.Base;

namespace ChessLib.API.Generic;

/// <summary>
/// Contains the move and board at every step in a game of chess
/// </summary>
public class Game(Board starting) : IEnumerable<Node>
{
    private readonly List<Node> _moves = new();
    private readonly Board _current = starting;
    
    public Node this[int i] => _moves[i];
    public Node this[Index i] => _moves[i];

    /// <summary>
    /// Adds a move to the game
    /// </summary>
    public void AddMove(Move move)
    {
        _moves.Add(new Node(_current.Clone(), move));
        _current.MakeMove(move);
    }
    
    /// <summary>
    /// Parses the move provided according to algebraic notation and adds it to the game
    /// </summary>
    public void AddMove(string move)
    {
        AddMove(_current.ParseMove(move));
    }

    public Game(Board starting, IEnumerable<Move> moves) : this(starting)
    {
        foreach (var move in moves)
            AddMove(move);
    }

    public Game(Board starting, string[] moves) : this(starting)
    {
        foreach (var move in moves)
            AddMove(move);
    }
    
    public Game(Board starting, string game) : this(starting)
    {
        foreach (var move in game.StripMoves())
            AddMove(move);
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