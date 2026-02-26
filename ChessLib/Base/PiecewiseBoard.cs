using System.Runtime.CompilerServices;

namespace ChessLib.Base.Utils;

/*
 * Stores the pieces as they appear on the board
 * Starts at a1
 */

[InlineArray(64)]
public struct PiecewiseBoard
{
    public byte Piece;
}