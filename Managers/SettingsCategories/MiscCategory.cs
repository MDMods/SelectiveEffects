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
        private static readonly MelonPreferences_Category Category;
        internal static readonly MelonPreferences_Entry<bool> _disableBossFx;
        internal static readonly MelonPreferences_Entry<bool> _disableDustFx;
        internal static readonly MelonPreferences_Entry<bool> _disableHurtFx;
        internal static readonly MelonPreferences_Entry<bool> _disableElfinFx;

        static MiscCategory()
        {
            Category = MelonPreferences.CreateCategory("Misc");
            Category.SetFilePath(SettingsPath, false, false);

            _disableBossFx = Category.CreateEntry("DisableBossFx", false);
            _disableElfinFx = Category.CreateEntry("DisableElfinFx", false);
            _disableDustFx = Category.CreateEntry("DisableDustFx", false);
            _disableHurtFx = Category.CreateEntry("DisableHurtFx", false, description: "Disable hp loss text.");
        }

        internal static void Init()
        {
            Category.LoadFromFile(false);
        }
    }
}