using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.MiscCategory;

internal class ElfinFx : EffectsBaseCondition
{
    private ElfinFx() { }

    internal static ElfinFx Instance { get; } = new();

    protected override bool SettingsValue => SettingsManager.Get<Managers.Misc>().DisableElfinFx;

    protected override bool Condition(string s)
    {
        return s.Contains("elfin");
    }
}
