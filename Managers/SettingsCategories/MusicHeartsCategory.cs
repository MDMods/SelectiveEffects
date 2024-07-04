using MelonLoader;

namespace SelectiveEffects.Managers;

internal class MusicHeartsCategory : Category
{
    private readonly MelonPreferences_Entry<bool> _disableHeartsFx;
    private readonly MelonPreferences_Entry<bool> _disableMusicNotesFx;

    public MusicHeartsCategory()
        : base("MusicHearts")
    {
        _disableMusicNotesFx = _category.CreateEntry(
            "DisableMusicNotesFx",
            false,
            description: "Disable music notes points text."
        );
        _disableHeartsFx = _category.CreateEntry(
            "DisableHeartsFx",
            false,
            description: "Disable hearts health gain text."
        );
    }

    internal bool DisableHeartsFx => _disableHeartsFx.Value;
    internal bool DisableMusicNotesFx => _disableMusicNotesFx.Value;
}
