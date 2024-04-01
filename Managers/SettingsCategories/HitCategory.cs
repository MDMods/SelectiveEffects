using MelonLoader;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    //--------------------------------------------------------------------+
    // Hit Category
    //--------------------------------------------------------------------+
    internal static bool DisableHitDisappearAnimations => HitCategory._disableHitDissapearAnimations.Value;
    internal static bool DisableHitEffects => HitCategory._disableHitEffects.Value;
    internal static bool DisableGirlFxAtk => HitCategory._disableGirlFxAtk.Value;
    internal static bool DisableGirlAtkParticles => HitCategory._disableGirlAtkParticles.Value;
    internal static bool DisablePressFx => HitCategory._disablePressFx.Value;

    internal static bool DisableHitEnemy => DisableHitDisappearAnimations
                                            && (DisableHitEffects || DisableGirlFxAtk);
    
    private static class HitCategory
    {
        internal static MelonPreferences_Entry<bool> _disableHitDissapearAnimations;
        internal static MelonPreferences_Entry<bool> _disableHitEffects;
        internal static MelonPreferences_Entry<bool> _disableGirlFxAtk;
        internal static MelonPreferences_Entry<bool> _disableGirlAtkParticles;
        internal static MelonPreferences_Entry<bool> _disablePressFx;

        internal static void Init()
        {
            var hitCategory = MelonPreferences.CreateCategory("Hit");
            hitCategory.SetFilePath(SettingsPath, true, false);

            _disableHitDissapearAnimations = hitCategory.CreateEntry("DisableHitDissapearAnimations", false,
                description: "Hit enemies disappear immeadiatly.");
            _disableHitEffects = hitCategory.CreateEntry("DisableHitEffects", false);
            _disableGirlFxAtk = hitCategory.CreateEntry("DisableGirlHitFx", false);
            _disableGirlAtkParticles = hitCategory.CreateEntry("DisableGirlHitParticlesOnly", false);
            _disablePressFx = hitCategory.CreateEntry("DisablePressFx", false);
        }
    }
}