using MelonLoader;
using SelectiveEffects.Managers;
using SelectiveEffects.Properties;

namespace SelectiveEffects;

public sealed partial class Main : MelonMod
{
    internal static bool IsGameMain { get; private set; }

    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        IsGameMain = sceneName.Equals("GameMain");
    }

    internal static void Reload(object sender, FileSystemEventArgs e)
    {
        SettingsManager.Load();
        EffectsDisablerManager.ReloadToggle();
        EffectsDisablerManager.Load();

        Melon<Main>.Logger.Msg("Reloaded successfully!");
    }
}