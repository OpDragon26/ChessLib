using ChessLib.Utils;

namespace ChessLib.API.Display;

public static class Mapping
{

    public static (int file, int rank) White(this (int file, int rank) square)
    {
        return (square.file, 7 - square.rank);
    }
    
    public static (int file, int rank) Black(this (int file, int rank) square)
    {
        return (7 - square.file, square.rank);
    }

    public static int White(this int index)
    {
        return index.AsSquare().White().AsIndex();
    }
    
    public static int Black(this int index)
    {
        return index.AsSquare().Black().AsIndex();
    }
}