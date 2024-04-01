using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

internal class Perfects : EffectsBaseCondition
{
    private Perfects()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisablePerfects || SettingsManager.DisableJudgement;

    internal static Perfects Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("Perfect");
    }
}