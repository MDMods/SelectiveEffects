using MelonLoader;

namespace SelectiveEffects.Managers;

internal class Fever : Category
{
    private readonly MelonPreferences_Entry<bool> _disableBG;
    private readonly MelonPreferences_Entry<bool> _disableFever;
    private readonly MelonPreferences_Entry<bool> _disableStars;
    private readonly MelonPreferences_Entry<bool> _disableTransition;

    public Fever()
        : base("Fever")
    {
        _disableFever = _category.CreateEntry("DisableFever", false);
        _disableBG = _category.CreateEntry("DisableBackground", false);
        _disableStars = _category.CreateEntry("DisableStars", false);
        _disableTransition = _category.CreateEntry("DisableTransition", false);
    }

    internal bool DisableBG => _disableBG.Value;
    internal bool DisableFever =>
        _disableFever.Value || (DisableBG && DisableStars && DisableTransition);
    internal bool DisableStars => _disableStars.Value;
    internal bool DisableTransition => _disableTransition.Value;
}
