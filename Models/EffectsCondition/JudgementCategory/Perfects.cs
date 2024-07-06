using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

internal class Perfects : EffectsBaseCondition
{
    private Perfects() { }

    internal static Perfects Instance { get; } = new();

    protected override bool SettingsValue
    {
        get
        {
            var judgementCategory = SettingsManager.Get<Managers.Judgement>();
            return judgementCategory.DisablePerfects || judgementCategory.DisableJudgement;
        }
    }

    protected override bool Condition(string s)
    {
        return s.Contains("Perfect");
    }
}
