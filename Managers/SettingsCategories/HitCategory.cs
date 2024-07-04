using MelonLoader;

namespace SelectiveEffects.Managers;

internal class HitCategory : ICategory
{
    private readonly MelonPreferences_Category Category;
    private readonly MelonPreferences_Entry<bool> _disableGirlAtkParticles;
    private readonly MelonPreferences_Entry<bool> _disableGirlFxAtk;
    private readonly MelonPreferences_Entry<bool> _disableHitDissapearAnimations;
    private readonly MelonPreferences_Entry<bool> _disableHitEffects;
    private readonly MelonPreferences_Entry<bool> _disablePressFx;

    public HitCategory()
    {
        Category = MelonPreferences.CreateCategory("Hit");
        Category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _disableHitDissapearAnimations = Category.CreateEntry(
            "DisableHitDisappearAnimations",
            false,
            description: "Hit enemies disappear immediately."
        );
        _disableHitEffects = Category.CreateEntry("DisableHitEffects", false);
        _disableGirlFxAtk = Category.CreateEntry("DisableGirlHitFx", false);
        _disableGirlAtkParticles = Category.CreateEntry("DisableGirlHitParticlesOnly", false);
        _disablePressFx = Category.CreateEntry("DisablePressFx", false);
    }

    internal bool DisableGirlAtkParticles => _disableGirlAtkParticles.Value;
    internal bool DisableGirlFxAtk => _disableGirlFxAtk.Value;
    internal bool DisableHitDisappearAnimations => _disableHitDissapearAnimations.Value;
    internal bool DisableHitEffects => _disableHitEffects.Value;
    internal bool DisableHitEnemy =>
        DisableHitDisappearAnimations && (DisableHitEffects || DisableGirlFxAtk);
    internal bool DisablePressFx => _disablePressFx.Value;

    void ICategory.Load()
    {
        Category.LoadFromFile(false);
    }

    void ICategory.Save()
    {
        Category.SaveToFile(false);
    }
}
