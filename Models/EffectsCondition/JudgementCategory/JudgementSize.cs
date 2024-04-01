namespace SelectiveEffects.Models.EffectsCondition.JudgementCategory;

// Unused
internal class JudgementSize : EffectsBaseCondition
{
    private JudgementSize()
    {
    }

    protected override bool SettingsValue => false;

    internal static JudgementSize Instance { get; } = new();

    protected override bool Condition(string s)
    {
        return s.Contains("Score");
    }
}