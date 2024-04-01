using SelectiveEffects.Properties;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    private const string SettingsPath = $"UserData/{MelonBuildInfo.ModName}.cfg";

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