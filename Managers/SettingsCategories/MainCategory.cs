using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Main Category
    //--------------------------------------------------------------------+
    internal static bool DisableAllEffects => MainCategory._disableAllEffects.Value;

    internal static bool IsEnabled
    {
        get => MainCategory._isEnabled.Value;
        set => MainCategory._isEnabled.Value = value;
    }

    private static class MainCategory
    {
        internal static MelonPreferences_Entry<bool> _disableAllEffects;
        internal static MelonPreferences_Entry<bool> _isEnabled;

        internal static void Init()
        {
            var mainCategory = MelonPreferences.CreateCategory("Main");
            mainCategory.SetFilePath(SettingsPath, true, false);

            _isEnabled = mainCategory.CreateEntry("Enabled", true, description: "Enable or disable the mod!");
            _disableAllEffects = mainCategory.CreateEntry("DisableAllEfects", true,
                description: "Takes precedence to the following options.");
        }
    }
}