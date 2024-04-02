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
        private static readonly MelonPreferences_Category Category;
        internal static readonly MelonPreferences_Entry<bool> _disableHitDissapearAnimations;
        internal static readonly MelonPreferences_Entry<bool> _disableHitEffects;
        internal static readonly MelonPreferences_Entry<bool> _disableGirlFxAtk;
        internal static readonly MelonPreferences_Entry<bool> _disableGirlAtkParticles;
        internal static readonly MelonPreferences_Entry<bool> _disablePressFx;

        static HitCategory()
        {
            Category = MelonPreferences.CreateCategory("Hit");
            Category.SetFilePath(SettingsPath, false, false);

            _disableHitDissapearAnimations = Category.CreateEntry("DisableHitDisappearAnimations", false,
                description: "Hit enemies disappear immediately.");
            _disableHitEffects = Category.CreateEntry("DisableHitEffects", false);
            _disableGirlFxAtk = Category.CreateEntry("DisableGirlHitFx", false);
            _disableGirlAtkParticles = Category.CreateEntry("DisableGirlHitParticlesOnly", false);
            _disablePressFx = Category.CreateEntry("DisablePressFx", false);
        }

        internal static void Init()
        {
            Category.LoadFromFile(false);
        }
    }
}