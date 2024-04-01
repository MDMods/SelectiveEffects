using MelonLoader;
using SelectiveEffects.Managers;
using SelectiveEffects.Properties;

namespace SelectiveEffects;

public partial class Main : MelonMod
{
    internal static bool _isGameMain;
    public static bool IsGameMain => _isGameMain;

    public override void OnInitializeMelon()
    {
        SettingsManager.Load();
        EffectsDisablerManager.Init();
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        _isGameMain = sceneName.Equals("GameMain");
    }
}