using MelonLoader;
using MuseDashMirror;
using SelectiveEffects.Managers;
using SelectiveEffects.Properties;

namespace SelectiveEffects;

public sealed partial class Main : MelonMod
{
    private static event Action ReloadEvent;

    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
    
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        // Reload if needed outside of GameMain
        if (SceneInfo.IsGameScene) return;
        ReloadEvent?.Invoke();
        ReloadEvent = null;
    }
    
    // Reload if needed before quitting to save the current settings
    public override void OnApplicationQuit()
    {
        SettingsManager.DisableWatcherEvents();
        ReloadEvent?.Invoke();
        base.OnApplicationQuit();
    }

    // Late initialization of the file watcher
    public override void OnLateInitializeMelon()
    {
        SettingsManager.EnableWatcherEvents();
    }

    internal static void QueueReload(object sender, FileSystemEventArgs e)
    {
        if (!SceneInfo.IsGameScene)
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