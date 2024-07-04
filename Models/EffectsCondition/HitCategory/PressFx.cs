using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.HitCategory;

internal class PressFx : EffectsBaseCondition
{
    private PressFx() { }

    internal static PressFx Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.HitCategory>().DisablePressFx;

    protected override bool Condition(string s)
    {
        return s.Contains("press_top_fx");
    }
}
