using SelectiveEffects.Managers;

namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

internal class Greats : EffectsBaseCondition
{
    private Greats() { }

    internal static Greats Instance { get; } = new();

    protected override bool SettingsValue
    {
        get
        {
            var judgementCategory = SettingsManager.Get<Managers.Judgement>();
            return judgementCategory.DisableGreats || judgementCategory.DisableJudgement;
        }
    }

    protected override bool Condition(string s)
    {
        return s.Contains("Great");
    }
}
