using MelonLoader;
using SelectiveEffects.Managers;

namespace SelectiveEffects
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            SettingsManager.Load();
            EffectsDisablerManager.Init();
            LoggerInstance.Msg("SelectiveEffects has loaded correctly!");
        }
    }
}
