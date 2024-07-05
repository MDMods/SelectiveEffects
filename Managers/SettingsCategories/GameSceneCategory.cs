using MelonLoader;

namespace SelectiveEffects.Managers;

internal class GameSceneCategory : Category
{
    private readonly MelonPreferences_Entry<bool> _disableElfin;
    private readonly MelonPreferences_Entry<bool> _disableGirl;

    public GameSceneCategory()
        : base("GameScene")
    {
        _disableGirl = _category.CreateEntry(
            "DisableGirl",
            false,
            description: "Disable girl's sprite."
        );
        _disableElfin = _category.CreateEntry(
            "DisableElfin",
            false,
            description: "Disable elfin's sprite."
        );
    }

    internal bool DisableElfin => _disableElfin.Value;
    internal bool DisableGirl => _disableGirl.Value;
}
