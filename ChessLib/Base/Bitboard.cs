using System.Runtime.CompilerServices;
using ChessLib.Base.Utils;

namespace ChessLib.Base.utils;

/*
 * Stores piece positions as bitboards
 * Index is the piece value
 */

[InlineArray(14)]
public struct Bitboard
{
    public ulong PieceBoard;
    
    public ulong All => AllWhite | AllBlack;
    public ulong AllWhite => this[2] | this[4] | this[6] | this[8] | this[10] | this[12];
    public ulong AllBlack => this[3] | this[5] | this[7] | this[9] | this[11] | this[13];

    public ulong AllType(byte type)
    {
        return this[type.AsColor(0)] | this[type.AsColor(1)];
    }
}