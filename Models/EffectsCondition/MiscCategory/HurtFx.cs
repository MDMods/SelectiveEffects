using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class HurtFx : EffectsBaseCondition
{
    private HurtFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableHurtFx;

    internal static HurtFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("TxtHurt");
    }
}