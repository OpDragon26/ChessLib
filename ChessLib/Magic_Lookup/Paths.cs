using ChessLib.Bitboards.Utils;
using ChessLib.Utils;

namespace ChessLib.Magic_Lookup;

public static class Paths
{
    public static readonly ButterflyBoard<ulong> LookupTable = new(GenPath);

    public static ulong GenPath(int from, int to)
    {
        (int file, int rank) start = from.AsSquare();
        (int file, int rank) end = to.AsSquare();

        if (start.rank == end.rank && start.file == end.file)
            return 0;

        ulong path = 0;

        // on the same file
        if (start.file == end.file)
        {
            int offset = start.rank < end.rank ? 1 : -1;
            for (int i = start.rank; i != end.rank; i += offset)
                path.EnableBit((start.file, i));
        }
            

        // on the same rank
        if (start.rank == end.rank)
        {
            int offset = start.file < end.file ? 1 : -1;
            for (int i = start.file; i != end.file; i += offset)
                path.EnableBit((i, start.rank));
        }
        
        // on the same up diagonal
        if (start.file - start.rank == end.file - end.rank)
        {
            (int file, int rank) offset = start.rank < end.rank ? (1, 1) : (-1, -1);
            for ((int file, int rank) current = start; current != end; current = current.OffsetBy(offset))
                path.EnableBit(current);
        }
            
        
        // on the same down diagonal
        if (7 - start.file - start.rank == 7 - end.file - end.rank)
        {
            (int file, int rank) offset = start.rank < end.rank ? (-1, 1) : (1, -1);
            for ((int file, int rank) current = start; current != end; current = current.OffsetBy(offset))
                path.EnableBit(current);
        }

        (int file, int rank) diff = (Math.Abs(start.file - end.file), Math.Abs(start.rank - end.rank));
        
        // horsey jump
        if (path != 0 || (diff.file + diff.rank == 3 && diff.file * diff.rank == 2))
        {
            path.EnableBit(from);
            path.EnableBit(to);
        }
        
        return path;
    }
}