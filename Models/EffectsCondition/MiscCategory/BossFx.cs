using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class BossFx : EffectsBaseCondition
{
    private BossFx() { }

    internal static BossFx Instance { get; } = new();

    protected override bool SettingsValue =>
        SettingsManager.Get<Managers.MiscCategory>().DisableBossFx;

    protected override bool Condition(string s)
    {
        return s.Contains("boss");
    }
}
