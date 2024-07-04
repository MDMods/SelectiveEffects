using MelonLoader;

namespace SelectiveEffects.Managers;

internal class MusicHeartsCategory : ICategory
{
    private readonly MelonPreferences_Category Category;
    private readonly MelonPreferences_Entry<bool> _disableHeartsFx;
    private readonly MelonPreferences_Entry<bool> _disableMusicNotesFx;

    public MusicHeartsCategory()
    {
        Category = MelonPreferences.CreateCategory("MusicHearts");
        Category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _disableMusicNotesFx = Category.CreateEntry(
            "DisableMusicNotesFx",
            false,
            description: "Disable music notes points text."
        );
        _disableHeartsFx = Category.CreateEntry(
            "DisableHeartsFx",
            false,
            description: "Disable hearts health gain text."
        );
    }

    internal bool DisableHeartsFx => _disableHeartsFx.Value;
    internal bool DisableMusicNotesFx => _disableMusicNotesFx.Value;

    void ICategory.Load()
    {
        Category.LoadFromFile(false);
    }

    void ICategory.Save()
    {
        Category.SaveToFile(false);
    }
}
