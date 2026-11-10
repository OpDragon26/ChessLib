using System.Collections;
using ChessLib.Base;

namespace ChessLib.Move_Generation;

public class MoveList : List<Move[]>, IEnumerable<Move>
{
    public readonly int Count = 0;
    public MoveList() : base(16)
    {
        
    }

    public void Add(Move[] moves)
    {
        
    }
    
    public MoveEnum GetEnumerator()
    {
        return new MoveEnum(this);
    }

    IEnumerator<Move> IEnumerable<Move>.GetEnumerator()
    {
        return (IEnumerator<Move>)GetEnumerator();
    }
}

public class MoveEnum : IEnumerator
{
    private MoveList MovesList;
    private int ListIndex;
    private int LocalIndex = -1;
    
    public MoveEnum(MoveList movesList)
    {
        MovesList = movesList;
    }

    public void Reset()
    {
        ListIndex = 0;
        LocalIndex = -1;
    }

    public bool MoveNext()
    {
        LocalIndex++;
        if (LocalIndex >= MovesList[ListIndex].Length)
        {
            LocalIndex = 0;
            ListIndex++;
        }

        return ListIndex < MovesList.Count;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Move Current => MovesList[ListIndex][LocalIndex];
}