using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

internal class Pass : EffectsBaseCondition
{
    private Pass()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisablePass || SettingsManager.DisableJudgement;

    internal static Pass Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("Pass");
    }
}