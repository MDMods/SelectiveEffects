using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

internal class Greats : EffectsBaseCondition
{
    private Greats()
    {
    }

    protected override bool SettingsValue => SettingsManager.DisableGreats || SettingsManager.DisableJudgement;

    internal static Greats Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("Great");
    }
}