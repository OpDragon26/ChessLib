using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Utils;

namespace ChessLib.API.Parsing;

public static class FEN
{
    public static Board ParseFEN(string fen)
    {
        string[] data = fen.Split(' ');

        PiecewiseBoard pieceBoard = ParsePiecePlecementData(data[0]);
        
        return new(pieceBoard);
    }

    private static PiecewiseBoard ParsePiecePlecementData(string data)
    {
        PiecewiseBoard board = new();
        string[] lines = data.Split('/');
        
        for (int rank = 7; rank >= 0; rank--)
        {
            int file = 0;
            
            foreach (char c in lines[rank])
            {
                (int file, int rank) square = (file, rank);
                int index = square.AsIndex();
                
                if (int.TryParse(c.ToString(), out int files))
                    for (int i = 0; i < files; i++)
                        board[index] = Pieces.Empty;
                else
                    board[index] = Piece.ParsePiece(c);
                
                file++;
            }
        }

        return board;
    }
}