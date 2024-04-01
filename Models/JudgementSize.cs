namespace SelectiveEffects.Models;

// Unused
internal class JudgementSize : EffectsCondition
{
    protected override bool Condition(string s)
    {
        return s.Contains("Score");
    }
}