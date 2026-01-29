using System.Runtime.CompilerServices;
using ChessLib.Bitboards;

namespace ChessLib.Base;

/*
 * Stores piece positions as bitboards
 * Index is the piece value
 */

[InlineArray(12)]
public struct Bitboard
{
    public ulong PieceBoard;
    
    public ulong All => AllWhite | AllBlack;
    public ulong AllWhite => this[0] | this[2] | this[4] | this[6] | this[8] | this[10];
    public ulong AllBlack => this[1] | this[3] | this[5] | this[7] | this[9] | this[11];

    public ulong AllType(byte type)
    {
        return this[type.AsColor(0)] | this[type.AsColor(1)];
    }
}