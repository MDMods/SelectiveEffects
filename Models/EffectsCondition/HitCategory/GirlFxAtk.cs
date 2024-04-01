using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.HitCategory;

internal class GirlFxAtk : EffectsBaseCondition
{
    private GirlFxAtk()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableGirlFxAtk;

    internal static GirlFxAtk Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("girl_fx_atk");
    }
}