using ChessLib.Bitboards;
using ChessLib.Magic_Lookup;
namespace ChessLib;

public static class ChessLib
{
    public static InitStage InitStage = InitStage.Uninitialized;
    
    /// <summary>
    /// Initializes the library and completes preprocessing steps. Necessary for many functions
    /// </summary>
    public static void Init()
    {
        if (InitStage != InitStage.Uninitialized)
            return;
        InitStage = InitStage.Ongoing;
            
        Masks.Init();
        Combinations.Init();
        Moves.Init();
        Pins.Init();

        InitStage = InitStage.Complete;
    }
}

public enum InitStage
{
    Uninitialized,
    Ongoing,
    Complete
}