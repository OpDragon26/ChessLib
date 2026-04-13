using System.Runtime.CompilerServices;

namespace ChessLib.Base;

/// <summary>
/// Stores the pieces as they appear on the board, starting at a1
/// </summary>

[InlineArray(64)]
public struct PiecewiseBoard
{
    public byte Piece;
}