using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Misc Category
    //--------------------------------------------------------------------+
    internal static bool DisableBossFx => MiscCategory._disableBossFx.Value;
    internal static bool DisableDustFx => MiscCategory._disableDustFx.Value;
    internal static bool DisableHurtFx => MiscCategory._disableHurtFx.Value;
    internal static bool DisableElfinFx => MiscCategory._disableElfinFx.Value;

    private static class MiscCategory
    {
        internal static MelonPreferences_Entry<bool> _disableBossFx;
        internal static MelonPreferences_Entry<bool> _disableDustFx;
        internal static MelonPreferences_Entry<bool> _disableHurtFx;
        internal static MelonPreferences_Entry<bool> _disableElfinFx;

        internal static void Init()
        {
            var miscCategory = MelonPreferences.CreateCategory("Misc");
            miscCategory.SetFilePath(SettingsPath, true, false);

            _disableBossFx = miscCategory.CreateEntry("DisableBossFx", false);
            _disableElfinFx = miscCategory.CreateEntry("DisableElfinFx", false);
            _disableDustFx = miscCategory.CreateEntry("DisableDustFx", false);
            _disableHurtFx = miscCategory.CreateEntry("DisableHurtFx", false, description: "Disable hp loss text.");
        }
    }
}