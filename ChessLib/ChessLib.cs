using ChessLib.Bitboards;
using ChessLib.Magic_Lookup;

namespace ChessLib;

public static class ChessLib
{
    public static InitStage InitStage = InitStage.Uninitialized;
    
    public static void Init()
    {
        if (InitStage != InitStage.Uninitialized)
            return;
        InitStage = InitStage.Ongoing;
        
        Masks.Init();
        Combinations.Init();
        Moves.Init();

        InitStage = InitStage.Complete;
    }
}

public enum InitStage
{
    Uninitialized,
    Ongoing,
    Complete
}