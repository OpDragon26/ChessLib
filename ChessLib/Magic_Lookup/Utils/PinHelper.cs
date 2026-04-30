using ChessLib.API.Parsing;
using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Bitboards.Utils;

namespace ChessLib.Magic_Lookup.Utils;

/// <summary>
/// Contains helper functions for dealing with pins
/// Requires pins to be initialized
/// </summary>
public static class PinHelper
{
    /// <summary>
    /// returns a set of potential bishop and rook pins as a dictionary where the square of the pinned piece is the key and the square of the potential pinner is the value.
    /// These pins still need to be tested whether they actually exist or not
    /// </summary>
    public static PinState PotentialPins(this Board board)
    {
        int square = board.KingPositions[board.Turn];
        ulong blockers = board.Bitboards.All;

        return Pins.Lookup.Pin(square, blockers);
    }

    /// <summary>
    /// Returns the set of bishop and rook pins on a given board. !Not to be used when performance is important!
    /// </summary>
    public static PinState FindPins(this Board board)
    {
        PinState potential = board.PotentialPins();

        return new(
            potential.Rook.Where(pin => board.ValidPin(pin, Pieces.Rook)).ToDictionary(),
            potential.Bishop.Where(pin => board.ValidPin(pin, Pieces.Bishop)).ToDictionary()
            );
    }

    /// <summary>
    /// Returns whether a pin is valid on a given board (assuming it was generated for the board)
    /// </summary>
    public static bool ValidPin(this Board board, KeyValuePair<int, int> pin, byte pieceType)
    {
        return board.ValidPin(pin.Key, pin.Value, pieceType);
    }
    
    /// <summary>
    /// Returns whether a pin is valid on a given board (assuming it was generated for the board)
    /// </summary>
    public static bool ValidPin(this Board board, int pinned, int pinner, byte pieceType)
    {
        return board.Bitboards.AllColor(board.Turn).Occupied(pinned)
                && (
                    board.Bitboards[pieceType.AsColor(board.Turn.Switch())] |
                    board.Bitboards[Pieces.Queen.AsColor(board.Turn.Switch())]
                ).Occupied(pinner);
    }
}