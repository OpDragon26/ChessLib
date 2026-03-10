using ChessLib.Magic_Lookup;

namespace ChessLib.Utils;

public static class MagicNumberGenerator
{
    public static MagicNumber Generate(ulong[] combinations, int shift = 48, bool improve = false, bool log = false)
    {
        int minShift = shift;

        if (log)
            Console.WriteLine(
                $"Generating magic numbers for {combinations.Length} combinations with a minimal shift of {shift}");

        ulong[] results = new ulong[combinations.Length];

        while (true)
        {
            MagicNumber number = new(GeneralUtils.Random(), shift, 0);

            if (number.IsValid(combinations, results, out ulong max))
                return !improve 
                    ? new(number.Number, number.Shift, (int)max)
                    : number.Improve(combinations);
            
            shift = minShift;
        }
    }

    private static bool IsValid(this MagicNumber number, ulong[] combinations, ulong[] result, out ulong max)
    {
        max = 0;

        for (int i = 0; i < combinations.Length; i++)
        {
            result[i] = number.Calculate(combinations[i]);
            if (result[i] > max)
                max = result[i];
        }

        max++;
        return result.Length == new HashSet<ulong>(result).Count;
    }

    private static MagicNumber Improve(this MagicNumber number, ulong[] combinations)
    {
        MagicNumber improved = new(number.Number, number.Shift + 1, number.Max);
        ulong[] result = new ulong[combinations.Length];

        if (improved.IsValid(combinations, result, out ulong max))
        {
            improved = new(improved.Number, improved.Shift, (int)max);
            return improved.Improve(combinations);
        }
        return number;
    }
}