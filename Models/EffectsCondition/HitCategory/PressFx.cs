using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.HitCategory;

internal class PressFx : EffectsBaseCondition
{
    private PressFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisablePressFx;

    internal static PressFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("press_top_fx");
    }
}