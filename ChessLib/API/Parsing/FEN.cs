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
        
        // castling availability
        CastlingRights castlingRights = ParseCastlingAvailability(data[2]);
        
        // en passant square
        int enPassantSquare = ParseEnPassantSquare(data[3]);
        
        return new(pieceBoard, color, enPassantSquare, castlingRights);
    }

    private static int ParseEnPassantSquare(string square)
    {
        if (square.Equals("-"))
            return 0;
        return square.ParseSquare().AsIndex();
    }

    private static CastlingRights ParseCastlingAvailability(string castling)
    {
        CastlingRights castlingRights = new(0);
        
        foreach (char c in castling) 
            switch (c)
            {
                case 'K':
                    castlingRights.WhiteShort = true;
                    break;
                    
                case 'Q':
                    castlingRights.WhiteLong = true;
                    break;
                
                case 'k':
                    castlingRights.BlackShort = true;
                    break;
                
                case 'q':
                    castlingRights.BlackLong = true;
                    break;
                
                case '-': break;
                
                default:
                    throw new ThrowHelper.NotationParsingException($"Unable to parse FEN string: invalid castling availability string: {castling}");
            }
        

        return castlingRights;
    }

    private static int ParseActiveColor(string color)
    {
        color = color.ToLower();
        if (color.Equals("w"))
            return 0;
        if (color.Equals("b"))
            return 1;
        throw new ThrowHelper.NotationParsingException($"Unable to parse FEN string: invalid color string: {color}");
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