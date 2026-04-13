namespace ChessLib.Bitboards.Utils;

/// <summary>
/// Stores all directions a piece can move in as tuples, as well as whether the piece is a sliding piece (rooks, bishops, queens) or not
/// </summary>
public class MovePattern((int file, int rank)[] offsets, bool sliding)
{
    public readonly (int file, int rank)[] Offsets = offsets;
    public readonly bool Sliding = sliding;
    
    public static readonly MovePattern Rook = new MovePattern(
    [
        (0,1),
        (1, 0),
        (0,-1),
        (-1, 0),
    ], true);
    
    public static readonly MovePattern Bishop = new MovePattern(
    [
        (1,1),
        (1, -1),
        (-1,1),
        (-1, -1),
    ], true);
    public static readonly MovePattern Knight = new MovePattern(
    [
        (2,1),
        (2, -1),
        (-2,1),
        (-2, -1),
        (1,2),
        (1, -2),
        (-1,2),
        (-1, -2),
    ], false);
}