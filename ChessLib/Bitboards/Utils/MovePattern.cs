namespace ChessLib.Bitboards.Utils;

public class MovePattern((int file, int rank)[] offsets, bool repeat)
{
    public readonly (int file, int rank)[] Offsets = offsets;
    public readonly bool Repeat = repeat;
    
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