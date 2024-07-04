using MelonLoader;

namespace SelectiveEffects.Managers;

internal class GameScene : Category
{
    private readonly MelonPreferences_Entry<bool> _disableElfin;
    private readonly MelonPreferences_Entry<bool> _disableGirl;

    public GameScene()
        : base("Stage")
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
