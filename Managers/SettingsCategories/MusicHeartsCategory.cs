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
        internal static MelonPreferences_Entry<bool> _disableMusicNotesFx;
        internal static MelonPreferences_Entry<bool> _disableHeartsFx;

        internal static void Init()
        {
            var musicHeartsCategory = MelonPreferences.CreateCategory("MusicHearts");
            musicHeartsCategory.SetFilePath(SettingsPath, true, false);

            _disableMusicNotesFx = musicHeartsCategory.CreateEntry("DisableMusicNotesFx", false,
                description: "Disable music notes points text.");
            _disableHeartsFx = musicHeartsCategory.CreateEntry("DisablHeartsFx", false,
                description: "Disable hearts health gain text.");
        }
    }
}