using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class DustFx : EffectsBaseCondition
{
    private DustFx() { }

    internal static DustFx Instance { get; } = new();

    protected override bool SettingsValue => SettingsManager.Get<Managers.Misc>().DisableDustFx;

    protected override bool Condition(string s)
    {
        return s.Contains("dust_fx");
    }
}
