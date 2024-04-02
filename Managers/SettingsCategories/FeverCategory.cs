using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Fever Category
    //--------------------------------------------------------------------+
    internal static bool DisableFever => FeverCategory._disableFever.Value
                                         || (DisableBG && DisableStars && DisableTransition);

    internal static bool DisableBG => FeverCategory._disableBG.Value;
    internal static bool DisableStars => FeverCategory._disableStars.Value;
    internal static bool DisableTransition => FeverCategory._disableTransition.Value;

    private static class FeverCategory
    {
        private static readonly MelonPreferences_Category Category;
        internal static readonly MelonPreferences_Entry<bool> _disableFever;
        internal static readonly MelonPreferences_Entry<bool> _disableBG;
        internal static readonly MelonPreferences_Entry<bool> _disableStars;
        internal static readonly MelonPreferences_Entry<bool> _disableTransition;

        static FeverCategory()
        {
            Category = MelonPreferences.CreateCategory("Fever");
            Category.SetFilePath(SettingsPath, false, false);

            _disableFever = Category.CreateEntry("DisableFever", false);
            _disableBG = Category.CreateEntry("DisableBackground", false);
            _disableStars = Category.CreateEntry("DisableStars", false);
            _disableTransition = Category.CreateEntry("DisableTransition", false);
        }


        internal static void Init()
        {
            Category.LoadFromFile(false);
        }
    }
}