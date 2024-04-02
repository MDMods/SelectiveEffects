using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Music notes & Hearts Category
    //--------------------------------------------------------------------+
    internal static bool DisableMusicNotesFx => MusicHeartsCategory._disableMusicNotesFx.Value;
    internal static bool DisableHeartsFx => MusicHeartsCategory._disableHeartsFx.Value;

    private static class MusicHeartsCategory
    {
        private static readonly MelonPreferences_Category Category;
        internal static readonly MelonPreferences_Entry<bool> _disableMusicNotesFx;
        internal static readonly MelonPreferences_Entry<bool> _disableHeartsFx;

        static MusicHeartsCategory()
        {
            Category = MelonPreferences.CreateCategory("MusicHearts");
            Category.SetFilePath(SettingsPath, false, false);

            _disableMusicNotesFx = Category.CreateEntry("DisableMusicNotesFx", false,
                description: "Disable music notes points text.");
            _disableHeartsFx = Category.CreateEntry("DisablHeartsFx", false,
                description: "Disable hearts health gain text.");
        }

        internal static void Init()
        {
            Category.LoadFromFile(false);
        }
    }
}