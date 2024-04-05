using MelonLoader;
using SelectiveEffects.Managers;
using SelectiveEffects.Properties;

namespace SelectiveEffects;

public sealed partial class Main : MelonMod
{
    internal static bool IsGameMain { get; private set; }
    private static event Action ReloadEvent;

    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
    
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        IsGameMain = string.Equals(sceneName, "GameMain");

        // Reload if needed outside of GameMain
        if (IsGameMain) return;
        ReloadEvent?.Invoke();
        ReloadEvent = null;
    }
    
    // Reload if needed before quitting to save the current settings
    public override void OnApplicationQuit()
    {
        ReloadEvent?.Invoke();
    }

    // Late initialization of the file watcher
    public override void OnLateInitializeMelon()
    {
        SettingsManager.EnableWatcherEvents();
    }

    internal static void QueueReload(object sender, FileSystemEventArgs e)
    {
        if (!IsGameMain)
        {
            Reload();
            return;
        }

        ReloadEvent = null;
        ReloadEvent += Reload;
    }

    private static void Reload()
    {
        SettingsManager.Load();
        EffectsDisablerManager.ReloadToggle();
        EffectsDisablerManager.Load();

        Melon<Main>.Logger.Msg("Reloaded successfully!");
    }
}