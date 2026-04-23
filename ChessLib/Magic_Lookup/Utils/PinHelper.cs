using ChessLib.API.Parsing;
using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Bitboards.Utils;

namespace ChessLib.Magic_Lookup.Utils;

public static class PinHelper
{
    public static PinState PotentialPins(this Board board)
    {
        int square = board.KingPositions[board.Turn];
        ulong blockers = board.Bitboards.All;

        return Pins.Lookup.Pin(square, blockers);
    }

    public static PinState ActualPins(this Board board)
    {
        PinState potential = board.PotentialPins();

        return new(
            potential.Rook.Where(pin => board.ValidPin(pin.Key, pin.Value, Pieces.Rook)).ToDictionary(),
            potential.Bishop.Where(pin => board.ValidPin(pin.Key, pin.Value, Pieces.Bishop)).ToDictionary()
            );
    }

    public static bool ValidPin(this Board board, int pinned, int pinner, byte pieceType)
    {
        return board.Bitboards.AllColor(board.Turn).Occupied(pinned)
                && (
                    board.Bitboards[pieceType.AsColor(board.Turn.Switch())] |
                    board.Bitboards[Pieces.Queen.AsColor(board.Turn.Switch())]
                ).Occupied(pinner);
    }
}