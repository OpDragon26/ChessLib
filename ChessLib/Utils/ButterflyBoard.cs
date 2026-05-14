namespace ChessLib.Utils;

/// <summary>
/// Stores a value for each pair of squares indexed as to and from
/// </summary>
public class ButterflyBoard<T>()
{
    private readonly T[,] Board = new T[64, 64];
    public T this[int from, int to] => Board[from, to];

    /// <summary>
    /// Fills the butterfly board using the given function f(int from, int to) -> T
    /// </summary>
    public void Fill(Func<int, int, T> filler)
    {
        for (int from = 0; from < 64; from++)
        for (int to = 0; to < 64; to++)
            Board[from, to] = filler(from, to);
    }

    /// <summary>
    /// Fills the butterfly board using the given function f(int from, int to) -> T
    /// </summary>
    public ButterflyBoard(Func<int, int, T> filler) : this()
    {
        Fill(filler);
    }
}