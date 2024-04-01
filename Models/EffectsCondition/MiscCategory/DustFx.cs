using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class DustFx : EffectsBaseCondition
{
    private DustFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableDustFx;

    internal static DustFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("dust_fx");
    }
}