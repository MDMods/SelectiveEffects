using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class ElfinFx : EffectsBaseCondition
{
    private ElfinFx()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableElfinFx;

    internal static ElfinFx Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("elfin");
    }
}