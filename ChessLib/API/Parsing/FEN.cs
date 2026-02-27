using ChessLib.Base;
using ChessLib.Base.Utils;
using ChessLib.Utils;

namespace ChessLib.API.Parsing;

public static class FEN
{
    public static Board ParseFEN(string fen)
    {
        string[] data = fen.Split(' ');

        // piece placement data
        PiecewiseBoard pieceBoard = ParsePiecePlecementData(data[0]);
        
        // active color
        int color = ParseActiveColor(data[1]);
        
        return new(pieceBoard, color);
    }

    private static int ParseActiveColor(string color)
    {
        color = color.ToLower();
        if (color.Equals("w"))
            return 0;
        if (color.Equals("b"))
            return 1;
        throw new ThrowHelper.NotationParsingException($"Unable to parse FEN string: unknow color string: {color}");
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