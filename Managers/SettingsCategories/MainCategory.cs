using MelonLoader;

namespace SelectiveEffects.Managers;

internal class MainCategory : Category
{
    private readonly MelonPreferences_Entry<bool> _disableAllEffects;
    private readonly MelonPreferences_Entry<bool> _isEnabled;

    public MainCategory()
        : base("Main")
    {
        _isEnabled = _category.CreateEntry(
            "Enabled",
            true,
            description: "Enable or disable the mod!"
        );
        _disableAllEffects = _category.CreateEntry(
            "DisableAllEffects",
            true,
            description: "Takes precedence to the following options."
        );
    }

    internal bool DisableAllEffects => _disableAllEffects.Value;

    internal bool IsEnabled
    {
        get => _isEnabled.Value;
        set => _isEnabled.Value = value;
    }
}
