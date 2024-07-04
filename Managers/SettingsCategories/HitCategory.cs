using MelonLoader;

namespace SelectiveEffects.Managers;

internal class HitCategory : Category
{
    private readonly MelonPreferences_Entry<bool> _disableGirlAtkParticles;
    private readonly MelonPreferences_Entry<bool> _disableGirlFxAtk;
    private readonly MelonPreferences_Entry<bool> _disableHitDisappearAnimations;
    private readonly MelonPreferences_Entry<bool> _disableHitEffects;
    private readonly MelonPreferences_Entry<bool> _disablePressFx;

    public HitCategory()
        : base("Hit")
    {
        _disableHitDisappearAnimations = _category.CreateEntry(
            "DisableHitDisappearAnimations",
            false,
            description: "Hit enemies disappear immediately."
        );
        _disableHitEffects = _category.CreateEntry("DisableHitEffects", false);
        _disableGirlFxAtk = _category.CreateEntry("DisableGirlHitFx", false);
        _disableGirlAtkParticles = _category.CreateEntry("DisableGirlHitParticlesOnly", false);
        _disablePressFx = _category.CreateEntry("DisablePressFx", false);
    }

    internal bool DisableGirlAtkParticles => _disableGirlAtkParticles.Value;
    internal bool DisableGirlFxAtk => _disableGirlFxAtk.Value;
    internal bool DisableHitDisappearAnimations => _disableHitDisappearAnimations.Value;
    internal bool DisableHitEffects => _disableHitEffects.Value;
    internal bool DisableHitEnemy =>
        DisableHitDisappearAnimations && (DisableHitEffects || DisableGirlFxAtk);
    internal bool DisablePressFx => _disablePressFx.Value;
}
