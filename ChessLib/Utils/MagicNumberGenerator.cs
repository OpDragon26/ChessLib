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

    public static MagicNumber Generate(ulong[] combinations, int iterations, int shift = 48, bool improve = false, bool log = false)
    {
        MagicNumber best = new();

        if (log)
            Console.WriteLine(
                $"Generating magic numbers for {combinations.Length} combinations with a minimal shift of {shift}");
        
        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine($"i {i + 1}/{iterations}");
            MagicNumber candidate = Generate(combinations, shift, improve);

            if (candidate.BetterThan(best))
                best = candidate;
        }

        return best;
    }

    public static MagicNumber GenerateParallel(ulong[] combinations, int threads = 5, int shift = 48, bool log = false)
    {
        bool finished = false;
        MagicNumber magic = new();
        Mutex InitMutex = new();
        
        if (log)
            Console.WriteLine(
                $"Generating magic numbers in parallel for {combinations.Length} combinations with a set shift of {shift}");
        
        for (int t = 0; t < threads; t++)
        {
            new Thread(() =>
            {
                ulong[] results = new ulong[combinations.Length];
                
                while (true)
                {
                    InitMutex.WaitOne();
                    if (finished)
                    {
                        InitMutex.ReleaseMutex();
                        break;
                    }
                    MagicNumber candidate = new(GeneralUtils.Random(), shift, 0);
                    InitMutex.ReleaseMutex();

                    if (candidate.IsValid(combinations, results, out ulong max))
                    {
                        InitMutex.WaitOne();
                        magic = new(candidate.Number, candidate.Shift, (int)max);
                        finished = true;
                        InitMutex.ReleaseMutex();
                    }
                }
            }).Start();
        }

        while (!finished)
            Thread.Sleep(100);
        
        return magic;
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