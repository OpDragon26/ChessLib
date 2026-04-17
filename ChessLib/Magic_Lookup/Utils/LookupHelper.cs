namespace ChessLib.Magic_Lookup.Utils;

public static class LookupHelper
{
    /// <summary>
    /// Fills a magic lookup table using the given specifications
    /// </summary>
    public static void FillLookupTable<T>(this T[][] table, MagicNumber[] magics, ulong[][] combinationSet, Func<int, ulong, T> selector)
    {
        for (int s = 0; s < 64; s++)
        {
            MagicNumber magic = magics[s];
            table[s] = new T[magic.Max];
        
            foreach (ulong combination in combinationSet[s])
            {
                ulong index = magic.Calculate(combination);
                table[s][index] = selector(s, combination);
            }
        }
    }

    /// <summary>
    /// Performs a magic lookup on the given table
    /// </summary>
    public static T Lookup<T>(this T[][] table, MagicNumber[] magics, int square, ulong key)
    {
        MagicNumber magic = magics[square];
        ulong index = magic.Calculate(key);
        return table[square][index];
    }
}