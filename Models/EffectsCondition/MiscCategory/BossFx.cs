using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class BossFx : EffectsBaseCondition
{
    private BossFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableBossFx;

    internal static BossFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("boss");
    }
}