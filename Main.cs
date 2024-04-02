using MelonLoader;
using SelectiveEffects.Managers;
using SelectiveEffects.Properties;

namespace SelectiveEffects;

public sealed partial class Main : MelonMod
{
    private static event Action _queueReload;
    
    internal static string CurrentScene { get; private set; }
    internal static bool IsGameMain => CurrentScene.Equals("GameMain");

    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        CurrentScene = sceneName;
        
        if (IsGameMain) return;
        _queueReload?.Invoke();
    }

    internal static void QueueReload(object sender, FileSystemEventArgs e)
    {
        if (!IsGameMain)
        {
            Reload();
            return;
        }
        
        _queueReload -= Reload;
        _queueReload += Reload;
    }

    private static void Reload()
    {
        SettingsManager.Load();
        EffectsDisablerManager.ReloadToggle();
        EffectsDisablerManager.Load();

        Melon<Main>.Logger.Msg("Reloaded successfully!");
    }
}