using MelonLoader;
using SelectiveEffects.Managers;
using SelectiveEffects.Properties;

namespace SelectiveEffects;

public sealed partial class Main : MelonMod
{
    private static event Action ReloadEvent;

    public static bool IsGameScene { get; private set; } = false;

    // Reload if needed before quitting to save the current settings
    public override void OnApplicationQuit()
    {
        SettingsManager.DisableWatcherEvents();
        ReloadEvent?.Invoke();
        base.OnApplicationQuit();
    }

    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    // Late initialization of the file watcher
    public override void OnLateInitializeMelon()
    {
        SettingsManager.EnableWatcherEvents();
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        IsGameScene = sceneName?.Equals("GameMain") ?? false;
        // Reload if needed outside of GameMain
        if (IsGameScene)
        {
            return;
        }

        ReloadEvent?.Invoke();
        ReloadEvent = null;
    }

    internal static void QueueReload(object sender, FileSystemEventArgs e)
    {
        if (!IsGameScene)
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
        EffectsDisablerManager.Load();

        Melon<Main>.Logger.Msg("Reloaded successfully!");
    }
}
