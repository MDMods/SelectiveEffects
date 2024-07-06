using MelonLoader;

namespace SelectiveEffects.Managers;

internal class Misc : Category
{
    private readonly MelonPreferences_Entry<bool> _disableBossFx;
    private readonly MelonPreferences_Entry<bool> _disableDustFx;
    private readonly MelonPreferences_Entry<bool> _disableElfinFx;
    private readonly MelonPreferences_Entry<bool> _disableHurtFx;

    public Misc()
        : base("Misc")
    {
        _disableBossFx = _category.CreateEntry("DisableBossFx", false);
        _disableElfinFx = _category.CreateEntry("DisableElfinFx", false);
        _disableDustFx = _category.CreateEntry("DisableDustFx", false);
        _disableHurtFx = _category.CreateEntry(
            "DisableHurtFx",
            false,
            description: "Disable hp loss text."
        );
    }

    internal bool DisableBossFx => _disableBossFx.Value;
    internal bool DisableDustFx => _disableDustFx.Value;
    internal bool DisableElfinFx => _disableElfinFx.Value;
    internal bool DisableHurtFx => _disableHurtFx.Value;
}
