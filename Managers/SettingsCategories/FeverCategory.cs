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
        internal static MelonPreferences_Entry<bool> _disableFever;
        internal static MelonPreferences_Entry<bool> _disableBG;
        internal static MelonPreferences_Entry<bool> _disableStars;
        internal static MelonPreferences_Entry<bool> _disableTransition;


        internal static void Init()
        {
            var feverCategory = MelonPreferences.CreateCategory("Fever");
            feverCategory.SetFilePath(SettingsPath, true, false);

            _disableFever = feverCategory.CreateEntry("DisableFever", false);
            _disableBG = feverCategory.CreateEntry("DisableBackground", false);
            _disableStars = feverCategory.CreateEntry("DisableStars", false);
            _disableTransition = feverCategory.CreateEntry("DisableTransition", false);
        }
    }
}