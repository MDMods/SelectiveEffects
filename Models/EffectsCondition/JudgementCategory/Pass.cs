using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

internal class Pass : EffectsBaseCondition
{
    private Pass() { }

    internal static Pass Instance { get; } = new();

    protected override bool SettingsValue
    {
        get
        {
            var judgementCategory = SettingsManager.Get<Managers.Judgement>();
            return judgementCategory.DisablePass || judgementCategory.DisableJudgement;
        }
    }

    protected override bool Condition(string s)
    {
        return s.Contains("Pass");
    }
}
