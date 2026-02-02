using ChessLib.Utils;

namespace ChessLib.API.Generic;

/// <summary>
/// Stores a coordinate with the perspective in mind
/// </summary>
public readonly struct Coordinate(Perspective perspective, int file, int rank)
{
    public Coordinate(Perspective perspective, (int file, int rank) square) : this(perspective, square.file, square.rank) {}
    public Coordinate(int file, int rank) : this(Perspective.Objective, file, rank) {}
    public Coordinate((int file, int rank) square) : this(Perspective.Objective, square.file, square.rank) {}
    public Coordinate(int index) : this(Perspective.Objective, index.AsSquare()) {}
    public Coordinate(Perspective perspective, int index) : this(perspective, index.AsSquare()) {}
    
    public readonly Perspective Perspective = perspective;
    public readonly int File = file;
    public readonly int Rank = rank;
    
    public Coordinate ToObjective()
    {
        return Perspective switch
        {
            Perspective.Objective => this,
            Perspective.White => new Coordinate(File, -Rank),
            Perspective.Black => new Coordinate(-File, Rank),
            _ => throw new Exception("no")
        };
    }
    
    public Coordinate ToWhite()
    {
        return Perspective switch
        {
            Perspective.Objective => new Coordinate(File, -Rank),
            Perspective.White => this,
            Perspective.Black => new Coordinate(-File, -Rank),
            _ => throw new Exception("no")
        };
    }
    
    public Coordinate ToBlack()
    {
        return Perspective switch
        {
            Perspective.Objective => new Coordinate(-File, Rank),
            Perspective.White => new Coordinate(-File, -Rank),
            Perspective.Black => this,
            _ => throw new Exception("no")
        };
    }

    /// <summary>
    /// Returns the coordinate as an objective tuple
    /// </summary>
    public (int file, int rank) AsTuple()
    {
        Coordinate o = ToObjective();
        return (o.File, o.Rank);
    }

    /// <summary>
    /// Returns the coordinate as an objective index
    /// </summary>
    public int AsIndex()
    {
        return AsTuple().AsIndex();
    }
}

public enum Perspective
{
    White,
    Black,
    Objective
}