using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    private const string SettingsPath = "UserData/SelectiveEffects.cfg";

    internal static void Load()
    {
        MainCategory.Init();
        FeverCategory.Init();
        JudgementCategory.Init();
        HitCategory.Init();
        MusicHeartsCategory.Init();
        MiscCategory.Init();
    }
}