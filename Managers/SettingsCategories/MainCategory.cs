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
        private static readonly MelonPreferences_Category Category;
        internal static readonly MelonPreferences_Entry<bool> _disableAllEffects;
        internal static readonly MelonPreferences_Entry<bool> _isEnabled;

        static MainCategory()
        {
            Category = MelonPreferences.CreateCategory("Main");
            Category.SetFilePath(SettingsPath, false, false);

            _isEnabled = Category.CreateEntry("Enabled", true, description: "Enable or disable the mod!");
            _disableAllEffects = Category.CreateEntry("DisableAllEffects", true,
                description: "Takes precedence to the following options.");
        }

        internal static void Init()
        {
            Category.LoadFromFile(false);
        }
    }
}