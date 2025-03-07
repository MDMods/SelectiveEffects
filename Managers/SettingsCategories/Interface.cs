using MelonLoader;

namespace SelectiveEffects.Managers;

internal class Interface : Category
{
    private readonly MelonPreferences_Entry<bool> _disableHealthBar;
    private readonly MelonPreferences_Entry<bool> _disableScore;
    private readonly MelonPreferences_Entry<bool> _disableCombo;
    private readonly MelonPreferences_Entry<bool> _disablePauseButton;
    private readonly MelonPreferences_Entry<bool> _disableProgressBar;

    public Interface()
        :base("Interface")
    {
        _disableHealthBar = _category.CreateEntry(
            "DisableHealthBar",
            false,
            description: "Disable the health & fever bar."
        );

        _disableScore = _category.CreateEntry(
            "DisableScore",
            false,
            description: "Disable the score."
        );

        _disableCombo = _category.CreateEntry(
            "DisableCombo",
            false,
            description: "Disable the combo."
        );

        _disablePauseButton = _category.CreateEntry(
            "DisablePauseButton",
            false,
            description: "Disable the pause button."
        );

        _disableProgressBar = _category.CreateEntry(
            "DisableProgressBar",
            false,
            description: "Disable the progress bar."
        );
    }

    internal bool DisableHealthBar => _disableHealthBar.Value;
    internal bool DisableScore => _disableScore.Value;
    internal bool DisableCombo => _disableCombo.Value;
    internal bool DisablePauseButton => _disablePauseButton.Value;
    internal bool DisableProgressBar => _disableProgressBar.Value;
}
